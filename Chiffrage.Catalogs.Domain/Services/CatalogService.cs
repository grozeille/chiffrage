using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Domain.Events;
using Chiffrage.Mvc.Services;
using AutoMapper;
using System.IO;
using CsvHelper;
using NPOI.HSSF.UserModel;
using OfficeOpenXml;

namespace Chiffrage.Catalogs.Domain.Services
{
    public class CatalogService : IService
    {
        private readonly IEventBroker eventBroker;
        private readonly ICatalogRepository repository;
        
        public CatalogService(
            IEventBroker eventBroker,
            ICatalogRepository repository)
        {
            this.repository = repository;
            this.eventBroker = eventBroker;
        }

        [Subscribe]
        public void ProcessAction(CreateNewCatalogCommand eventObject)
        {
            var catalog = new SupplierCatalog();
            catalog.SupplierName = eventObject.Name;

            this.repository.Save(catalog);

            this.eventBroker.Publish(new CatalogCreatedEvent(catalog));
        }

        [Subscribe]
        public void ProcessAction(UpdateCatalogCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            catalog.SupplierName = eventObject.Name;
            catalog.Comment = eventObject.Comment;

            this.repository.Save(catalog);

            this.eventBroker.Publish(new CatalogUpdatedEvent(catalog));
        }

        [Subscribe]
        public void ProcessAction(CreateNewSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            Mapper.CreateMap<CreateNewSupplyCommand, Supply>();

            var supply = Mapper.Map<CreateNewSupplyCommand, Supply>(eventObject);

            // supply name must be unique
            if (catalog.Supplies.Where(x => x.Name.Equals(eventObject.Name, System.StringComparison.OrdinalIgnoreCase)).Any())
            {
                this.eventBroker.Publish(new SupplyMustBeUniqueErrorEvent(catalog.Id, supply));
            }
            else
            {
                catalog.Supplies.Add(supply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new SupplyCreatedEvent(catalog.Id, supply));
            }
        }

        [Subscribe]
        public void ProcessAction(UpdateSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var supply = catalog.Supplies.Where(s => s.Id == eventObject.SupplyId).First();

            Mapper.CreateMap<UpdateSupplyCommand, Supply>();

            Mapper.Map(eventObject, supply);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new SupplyUpdatedEvent(catalog.Id, supply));
        }

        [Subscribe]
        public void ProcessAction(DeleteSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var supply = catalog.Supplies.Where(x => x.Id == eventObject.SupplyId).FirstOrDefault();

            if (supply != null)
            {
                catalog.Supplies.Remove(supply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new SupplyDeletedEvent(catalog.Id, supply));
            }
        }

        [Subscribe]
        public void ProcessAction(CreateNewHardwareCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            Mapper.CreateMap<CreateNewHardwareCommand, Hardware>();

            var hardware = Mapper.Map<CreateNewHardwareCommand, Hardware>(eventObject);

            // hardware name must be unique
            if (catalog.Hardwares.Where(x => x.Name.Equals(hardware.Name, System.StringComparison.OrdinalIgnoreCase)).Any())
            {
                this.eventBroker.Publish(new HardwareMustBeUniqueErrorEvent(catalog.Id, hardware));
            }
            else
            {
                catalog.Hardwares.Add(hardware);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareCreatedEvent(catalog.Id, hardware));
            }
        }

        [Subscribe]
        public void ProcessAction(UpdateHardwareCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var hardware = catalog.Hardwares.Where(s => s.Id == eventObject.HardwareId).First();

            Mapper.CreateMap<UpdateHardwareCommand, Hardware>();

            Mapper.Map(eventObject, hardware);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new HardwareUpdatedEvent(catalog.Id, hardware));
        }

        [Subscribe]
        public void ProcessAction(DeleteHardwareCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).FirstOrDefault();

            if (hardware != null)
            {
                catalog.Hardwares.Remove(hardware);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareDeletedEvent(catalog.Id, hardware));
            }
        }

        [Subscribe]
        public void ProcessAction(CreateNewHardwareSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var supply = catalog.Supplies.Where(x => x.Id == eventObject.SupplyId).First();

            var hardwareSupply = new HardwareSupply
            {
                Quantity = eventObject.Quantity,
                Comment = eventObject.Comment,
                Supply = supply
            };

            // supply name must be unique in hardaware components
            if (hardware.Components.Where(x => x.Id == supply.Id).Any())
            {
                this.eventBroker.Publish(new HardwareSupplyMustBeUniqueErrorEvent(catalog.Id, hardware.Id, supply));
            }
            else
            {
                hardware.Components.Add(hardwareSupply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareSupplyCreatedEvent(catalog.Id, hardware, hardwareSupply));
            }
        }

        [Subscribe]
        public void ProcessAction(DeleteHardwareSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var hardwareSupply = hardware.Components.Where(x => x.Id == eventObject.HardwareSupplyId).First();

            hardware.Components.Remove(hardwareSupply);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new HardwareSupplyDeletedEvent(catalog.Id, hardware, hardwareSupply));
        }

        [Subscribe]
        public void ProcessAction(UpdateHardwareSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var hardwareSupply = hardware.Components.Where(x => x.Id == eventObject.HardwareSupplyId).First();

            hardwareSupply.Quantity = eventObject.Quantity;
            hardwareSupply.Comment = eventObject.Comment;

            this.repository.Save(catalog);

            this.eventBroker.Publish(new HardwareSupplyUpdatedEvent(catalog.Id, hardware, hardwareSupply));
        }

        [Subscribe]
        public void ProcessAction(ImportHardwareCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var extension = Path.GetExtension(eventObject.FilePath);

            IEnumerable<CsvLine> lines = null;

            if (extension.Equals(".txt", StringComparison.OrdinalIgnoreCase) || extension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                using (var stream = File.Open(eventObject.FilePath, FileMode.Open, FileAccess.Read))
                {
                    using(var reader = new StreamReader(stream, Encoding.Default))
                    {
                        var csvReader = new CsvReader(reader);
                        csvReader.Configuration.Delimiter = ';';
                        
                        lines = csvReader.GetRecords<CsvLine>();
                    }
                }
            }
            else if (extension.Equals(".xls", StringComparison.OrdinalIgnoreCase))
            {
                using (var stream = File.Open(eventObject.FilePath, FileMode.Open, FileAccess.Read))
                {
                    var hssfwb = new HSSFWorkbook(stream);
                    
                    var sheet = hssfwb.GetSheetAt(0);

                    var extractedLines = new List<CsvLine>();
                    var emptyInt32TypeConverter = new EmptyInt32TypeConverter();
                    // skip the first row, it's the header
                    for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
                    {
                        var row = sheet.GetRow(rowIndex);
                        if (row != null)
                        {
                            var line = new CsvLine
                            {
                                Hardware = row.GetCell(0) == null ? string.Empty : row.GetCell(0).ToString(),
                                Supply = row.GetCell(1) == null ? string.Empty : row.GetCell(1).ToString(),
                                Reference = row.GetCell(2) == null ? string.Empty : row.GetCell(2).ToString(),
                                Module = (int)emptyInt32TypeConverter.ConvertFromString(row.GetCell(3) == null ? string.Empty : row.GetCell(3).ToString()),
                                Quantity = (int)emptyInt32TypeConverter.ConvertFromString(row.GetCell(4) == null ? string.Empty : row.GetCell(4).ToString()),
                                Comment = row.GetCell(5) == null ? string.Empty : row.GetCell(5).ToString()
                            };

                            extractedLines.Add(line);
                        }
                    }

                    lines = extractedLines;
                }
            }
            else if (extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                using (var stream = File.Open(eventObject.FilePath, FileMode.Open, FileAccess.Read))
                {
                    using (var excelPackage = new ExcelPackage(stream))
                    {
                        var sheet = excelPackage.Workbook.Worksheets[1];

                        var extractedLines = new List<CsvLine>();
                        var emptyInt32TypeConverter = new EmptyInt32TypeConverter();
                        // skip the first row, it's the header
                        for (int rowIndex = 2; rowIndex <= sheet.Dimension.End.Row; rowIndex++)
                        {
                            var line = new CsvLine
                            {
                                Hardware = sheet.Cells[rowIndex, 1].Text,
                                Supply = sheet.Cells[rowIndex, 2].Text,
                                Reference = sheet.Cells[rowIndex, 3].Text,
                                Module = (int)emptyInt32TypeConverter.ConvertFromString(sheet.Cells[rowIndex, 4].Text),
                                Quantity = (int)emptyInt32TypeConverter.ConvertFromString(sheet.Cells[rowIndex, 5].Text),
                                Comment = sheet.Cells[rowIndex, 6].Text
                            };

                            extractedLines.Add(line);
                        }

                        lines = extractedLines;
                    }
                }
            }

            var newSupplies = new List<Supply>();
            var newHardwares = new List<Hardware>();

            Hardware currentHardware = null;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line.Hardware))
                {
                    if (!string.IsNullOrEmpty(line.Supply))
                    {
                        FindOrCreateSupply(line, catalog.Supplies.Union(newSupplies), newSupplies);
                    }
                }
                else
                {
                    if (currentHardware == null || !currentHardware.Name.Equals(line.Hardware, StringComparison.OrdinalIgnoreCase))
                    {
                        currentHardware = new Hardware
                        {
                            Name = line.Hardware
                        };

                        newHardwares.Add(currentHardware);
                    }

                    var supply = FindOrCreateSupply(line, catalog.Supplies.Union(newSupplies), newSupplies);
                    currentHardware.Components.Add(new HardwareSupply
                    {
                        Comment = line.Comment,
                        Quantity = line.Quantity,
                        Supply = supply
                    });
                }
            }

            foreach (var item in newSupplies)
            {
                catalog.Supplies.Add(item);
            }

            foreach (var item in newHardwares)
            {
                catalog.Hardwares.Add(item);
            }

            this.repository.Save(catalog);

            foreach (var item in newSupplies)
            {
                this.eventBroker.Publish(new SupplyCreatedEvent(catalog.Id, item));
            }

            foreach (var item in newHardwares)
            {
                this.eventBroker.Publish(new HardwareCreatedEvent(catalog.Id, item));
            }
        }

        [Subscribe]
        public void ProcessAction(CopyCatalogCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            Mapper.CreateMap<SupplierCatalog, SupplierCatalog>();
            Mapper.CreateMap<Supply, Supply>();
            Mapper.CreateMap<Hardware, Hardware>();
            Mapper.CreateMap<Cable, Cable>();
            Mapper.CreateMap<HardwareSupply, HardwareSupply>();


            SupplierCatalog cloneCatalog = Mapper.Map<SupplierCatalog, SupplierCatalog>(catalog);
            cloneCatalog.SupplierName += " (copie)";
            cloneCatalog.Id = 0;

            cloneCatalog.Supplies = new List<Supply>();
            IDictionary<Int32, Supply> supplyCache = new Dictionary<Int32, Supply>();
            foreach (var s in catalog.Supplies)
            {
                Supply cloneSupply = Mapper.Map<Supply, Supply>(s);
                cloneSupply.Id = 0;
                cloneCatalog.Supplies.Add(cloneSupply);
                supplyCache.Add(s.Id, cloneSupply);
            }

            cloneCatalog.Hardwares = new List<Hardware>();
            foreach (var h in catalog.Hardwares)
            {
                Hardware cloneHardware = Mapper.Map<Hardware, Hardware>(h);
                cloneHardware.Id = 0;
                cloneCatalog.Hardwares.Add(cloneHardware);

                cloneHardware.Components = new List<HardwareSupply>();
                foreach (var s in h.Components)
                {
                    HardwareSupply cloneSupply = Mapper.Map<HardwareSupply, HardwareSupply>(s);
                    cloneSupply.Id = 0;
                    cloneSupply.Supply = supplyCache[cloneSupply.Supply.Id];
                    cloneHardware.Components.Add(s);
                }
            }

            cloneCatalog.Cables = new List<Cable>();
            foreach (var o in catalog.Cables)
            {
                Cable cloneCable = Mapper.Map<Cable, Cable>(o);
                cloneCable.Id = 0;
                cloneCatalog.Cables.Add(cloneCable);
            }

            this.repository.Save(cloneCatalog);

            this.eventBroker.Publish(new CatalogCreatedEvent(cloneCatalog));
        }

        [Subscribe]
        public void ProcessAction(DeleteCatalogCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            this.repository.Delete(catalog);

            this.eventBroker.Publish(new CatalogDeletedEvent(catalog.Id));
        }

        private Supply FindOrCreateSupply(CsvLine line, IEnumerable<Supply> suppliesToFind, IList<Supply> suppliesToAdd)
        {
            var supply = new Supply
            {
                Name = line.Supply,
                Reference = line.Reference,
                ModuleSize = line.Module
            };

            // search for it in the current catalog
            var foundSupply = suppliesToFind.Where(x => x.Name.Equals(supply.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (foundSupply == null)
            {
                suppliesToAdd.Add(supply);
                return supply;
            }
            else
            {
                return foundSupply;
            }
        }
    }
}

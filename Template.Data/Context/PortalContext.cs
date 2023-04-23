using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using Template.Data.Mappings;
using Template.Data.Mappings.Location;
using Template.Data.Mappings.Person;
using Template.Data.Mappings.Production;
using Template.Data.Mappings.Sales;
using Template.Data.Mappings.Usr;
using Template.Domain.Entities;
using Template.Domain.Entities.Invent;
using Template.Domain.Entities.Location;
using Template.Domain.Entities.Person;
using Template.Domain.Entities.Production;
using Template.Domain.Entities.Sales;
using Template.Domain.Entities.Usr;

namespace Template.Data.Context
{
    public class PortalContext : DbContext
    {
        public PortalContext(DbContextOptions<PortalContext> options)
            : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleItem> ModuleItems { get; set; }
        public DbSet<ModuleMenu> ModuleMenus { get; set; }
        public DbSet<ModuleProfile> ModuleProfiles { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryType> InventoryTypes { get; set; }

        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<AnnotationType> AnnotationTypes { get; set; }
        public DbSet<OpportunityType> OpportunityTypes { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Usr
            modelBuilder.ApplyConfiguration(new UsersMap()).Entity<Users>().ToTable("Users", schema: "Usr");
            modelBuilder.ApplyConfiguration(new ProfileMap()).Entity<Profile>().ToTable("Profile", schema: "Usr");
            modelBuilder.ApplyConfiguration(new ModuleMap()).Entity<Module>().ToTable("Module", schema: "Usr");
            modelBuilder.ApplyConfiguration(new ModuleItemMap()).Entity<ModuleItem>().ToTable("ModuleItem", schema: "Usr");
            modelBuilder.ApplyConfiguration(new ModuleMenuMap()).Entity<ModuleMenu>().ToTable("ModuleMenu", schema: "Usr");
            modelBuilder.ApplyConfiguration(new ModuleProfileMap()).Entity<ModuleProfile>().ToTable("ModuleProfile", schema: "Usr");
            #endregion



            #region Loc
            modelBuilder.ApplyConfiguration(new CountryMap()).Entity<Country>().ToTable("Country", schema: "Location");
            modelBuilder.ApplyConfiguration(new StateMap()).Entity<State>().ToTable("State", schema: "Location");
            modelBuilder.ApplyConfiguration(new CityMap()).Entity<City>().ToTable("City", schema: "Location");
            modelBuilder.ApplyConfiguration(new AddressMap()).Entity<Address>().ToTable("Address", schema: "Location");
            #endregion

            #region Person
            modelBuilder.ApplyConfiguration(new ContactMap()).Entity<Contact>().ToTable("Contact", schema: "Person");
            modelBuilder.ApplyConfiguration(new CompanyMap()).Entity<Company>().ToTable("Company", schema: "Person");
            modelBuilder.ApplyConfiguration(new BusinessUnitMap()).Entity<BusinessUnit>().ToTable("BusinessUnit", schema: "Person");
            #endregion

            #region Production
            modelBuilder.ApplyConfiguration(new ProductMap()).Entity<Product>().ToTable("Product", schema: "Production");
            modelBuilder.ApplyConfiguration(new ProductCategoryMap()).Entity<ProductCategory>().ToTable("ProductCategory", schema: "Production");
            modelBuilder.ApplyConfiguration(new ProductSubCategoryMap()).Entity<ProductSubCategory>().ToTable("ProductSubCategory", schema: "Production");
            modelBuilder.ApplyConfiguration(new ProductStatusMap()).Entity<ProductStatus>().ToTable("ProductStatus", schema: "Production");
            #endregion

            #region Inventory
            modelBuilder.ApplyConfiguration(new InventoryMap()).Entity<Inventory>().ToTable("Inventory", schema: "Inventory");
            modelBuilder.ApplyConfiguration(new InventoryItemMap()).Entity<InventoryItem>().ToTable("InventoryItem", schema: "Inventory");
            modelBuilder.ApplyConfiguration(new InventoryTypeMap()).Entity<InventoryType>().ToTable("InventoryType", schema: "Inventory");
            #endregion

            #region Sales
            modelBuilder.ApplyConfiguration(new OpportunityMap()).Entity<Opportunity>().ToTable("Opportunity", schema: "Sales");
            modelBuilder.ApplyConfiguration(new OrderMap()).Entity<Order>().ToTable("Order", schema: "Sales");
            modelBuilder.ApplyConfiguration(new ConceptMap()).Entity<Concept>().ToTable("Concept", schema: "Sales");
            modelBuilder.ApplyConfiguration(new AnnotationMap()).Entity<Annotation>().ToTable("Annotation", schema: "Sales");
            modelBuilder.ApplyConfiguration(new AnnotationTypeMap()).Entity<AnnotationType>().ToTable("AnnotationType", schema: "Sales");
            modelBuilder.ApplyConfiguration(new OpportunityTypeMap()).Entity<OpportunityType>().ToTable("OpportunityType", schema: "Sales");
            modelBuilder.ApplyConfiguration(new StageMap()).Entity<Stage>().ToTable("Stage", schema: "Sales");
            modelBuilder.ApplyConfiguration(new OrderProductMap()).Entity<OrderProduct>().ToTable("OrderProduct", schema: "Sales");
            #endregion

            ApplyGlobalStandards(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            Module[] _modules = new[]
            {
                new Module { Id = 1, Name = "Gestão", Icon = "pi pi-chart-pie", IsActive = true, Sequence = 1 },
                new Module { Id = 2, Name = "Estoque", Icon = "pi pi-shopping-bag", IsActive = true, Sequence = 2 },
                new Module { Id = 3, Name = "Vendas", Icon = "pi pi-building", IsActive = true, Sequence = 3 },
            };

            ModuleItem[] _moduleItems = new[]
            {
                new ModuleItem { Id = 1, Name = "Dashboards", ModuleId = 1, Icon = "pi pi-chart-pie", IsActive = true, Sequence = 1 },
                new ModuleItem { Id = 2, Name = "Usuários", ModuleId = 1, Icon = "pi pi-users", IsActive = true, Sequence = 2 },
                new ModuleItem { Id = 3, Name = "Configurações", ModuleId = 1, Icon = "pi pi-cog", IsActive = true, Sequence = 3 },
                new ModuleItem { Id = 4, Name = "Cadastro", ModuleId = 2, Icon = "pi pi-save", IsActive = false, Sequence = 4 },
                new ModuleItem { Id = 5, Name = "Inventário", ModuleId = 2, Icon = "pi pi-shopping-bag", IsActive = true, Sequence = 5 },
                new ModuleItem { Id = 6, Name = "Produtos", ModuleId = 2, Icon = "pi pi-shopping-cart", IsActive = false, Sequence = 6 },
                new ModuleItem { Id = 7, Name = "Empresas", ModuleId = 3, Icon = "pi pi-building", IsActive = true, Sequence = 7 },
                new ModuleItem { Id = 8, Name = "Oportunidades", ModuleId = 3, Icon = "pi pi-cart-plus", IsActive = true, Sequence = 8 },
                new ModuleItem { Id = 9, Name = "Pedidos", ModuleId = 3, Icon = "pi pi-gift", IsActive = true, Sequence = 9 },
            };


            ModuleMenu[] _moduleMenus = new[]
            {
                new ModuleMenu { Id = 1, Name = "Geral", ModuleItemId = 1, Icon = "pi pi-chart-line", URL = "dashboard/general", IsActive = true, Sequence = 1 },
                new ModuleMenu { Id = 2, Name = "Acessos", ModuleItemId = 2, Icon = "pi pi-id-card", URL = "users/access", IsActive = true, Sequence = 2 },
                new ModuleMenu { Id = 3, Name = "Cadastros", ModuleItemId = 3, Icon = "pi pi-save", URL = "config/registrations", IsActive = false, Sequence = 3 },
                new ModuleMenu { Id = 4, Name = "Ambiente", ModuleItemId = 3, Icon = "pi pi-wrench", URL = "config/environment", IsActive = true, Sequence = 4 },
                new ModuleMenu { Id = 5, Name = "Produtos", ModuleItemId = 3, Icon = "pi pi-shopping-cart", URL = "config/products", IsActive = true, Sequence = 5 },
                new ModuleMenu { Id = 6, Name = "Importações", ModuleItemId = 3, Icon = "pi pi-file-import", URL = "config/imports", IsActive = false, Sequence = 6 },
                new ModuleMenu { Id = 7, Name = "Stages", ModuleItemId = 3, Icon = "pi pi-directions", URL = "config/stages", IsActive = true, Sequence = 7 },
                new ModuleMenu { Id = 8, Name = "Produtos", ModuleItemId = 4, Icon = "pi pi-shopping-cart", URL = "registrations/products", IsActive = false, Sequence = 8 },
                new ModuleMenu { Id = 9, Name = "Produtos", ModuleItemId = 5, Icon = "pi pi-shopping-cart", URL = "inventory/products", IsActive = true, Sequence = 9 },
                new ModuleMenu { Id = 10, Name = "Gerenciar", ModuleItemId = 5, Icon = "pi pi-pencil", URL = "inventory/manager", IsActive = true, Sequence = 10 },
                new ModuleMenu { Id = 11, Name = "Visualizar", ModuleItemId = 6, Icon = "pi pi-eye", URL = "products/list", IsActive = false, Sequence = 11 },
                new ModuleMenu { Id = 12, Name = "Visualizar", ModuleItemId = 7, Icon = "pi pi-eye", URL = "clients/list", IsActive = true, Sequence = 12 },
                new ModuleMenu { Id = 13, Name = "Visualizar", ModuleItemId = 8, Icon = "pi pi-eye", URL = "opportunities/list", IsActive = true, Sequence = 13 },
                new ModuleMenu { Id = 14, Name = "Visualizar", ModuleItemId = 9, Icon = "pi pi-eye", URL = "orders/list", IsActive = true, Sequence = 14 },
            };

            Profile[] _profiles = new[]
            {
                new Profile { Id = 1, Name = "Admin", IsActive = true },
                new Profile { Id = 2, Name = "User", IsActive = true },
                new Profile { Id = 3, Name = "Seller", IsActive = true, IsDefault = true }
            };

            Users[] _users = new[]
            {
                new Users { Id = 1, Name = "Admin", IsActive = true, Email = "admin@template.com",
                    IsAuthorised = true, Password = "ad1d43bd6b763b66837db27749e96556aec373f5", CreatedUser = 1,
                    CreatedDate = DateTime.Now, ProfileId = 1},
                new Users { Id = 2, Name = "User", IsActive = true, Email = "user@template.com",
                    IsAuthorised = true, Password = "ad1d43bd6b763b66837db27749e96556aec373f5", CreatedUser = 1,
                    CreatedDate = DateTime.Now, ProfileId = 2},
                new Users { Id = 3, Name = "Seller", IsActive = true, Email = "seller@template.com",
                    IsAuthorised = true, Password = "ad1d43bd6b763b66837db27749e96556aec373f5", CreatedUser = 1,
                    CreatedDate = DateTime.Now, ProfileId = 3}
            };

            ModuleProfile[] _moduleProfiles = new[]
            {
                new ModuleProfile{ ProfileId = 1, ModuleId = 1 },
                new ModuleProfile{ ProfileId = 1, ModuleId = 2 },
                new ModuleProfile{ ProfileId = 1, ModuleId = 3 },
                new ModuleProfile{ ProfileId = 2, ModuleId = 2 },
                new ModuleProfile{ ProfileId = 2, ModuleId = 3 },
                new ModuleProfile{ ProfileId = 3, ModuleId = 3 },
            };

            ProductCategory[] _productCategory = new[]
            {
                new ProductCategory { Id = 1, Name = "Geral", IsActive = true },
            };

            ProductSubCategory[] _productSubCategory = new[]
            {
                new ProductSubCategory { Id = 1, Name = "Geral", ProductCategoryId = 1, IsActive = true },
            };

            ProductStatus[] _productStatus = new[]
            {
                new ProductStatus { Id = 1, Name = "Inativo", IsActive = true },
                new ProductStatus { Id = 2, Name = "Ativo", IsActive = true }
            };

            Product[] _product = new[]
            {
                new Product { Id = 1, Name = "Genérico", ProductCategoryId = 1, ProductSubCategoryId = 1, ProductStatusId = 1, IsActive = true },
            };

            InventoryType[] _inventoryType = new[]
            {
                new InventoryType { Id = 1, Name = "Entrada", IsActive = true },
                new InventoryType { Id = 2, Name = "Ajuste", IsActive = true },
                new InventoryType { Id = 3, Name = "Periódico", IsActive = true }
            };

            Inventory[] _inventory= new[]
            {
                new Inventory { Id = 1, InventoryTypeId = 1, Title = "Geral", Description = "Teste", IsActive = true }
            };

            InventoryItem[] _inventoryItem = new[]
            {
                new InventoryItem { Id = 1, ProductId = 1, SellPrice = 100.23, BuyPrice = 80.32, Barcode = "7889566423", Quantity = 4, InventoryId = 1, IsActive = true }
            };

            List<City> _cities = new List<City>();
            using (StreamReader r = new StreamReader("Z:\\TEMPLATES\\TERCEIROS\\sql-paises-estados-cidades-master\\cidade.json"))
            {
                string json = r.ReadToEnd();
                _cities = JsonSerializer.Deserialize<List<City>>(json);
            }


            List<State> _states = new List<State>();
            using (StreamReader r = new StreamReader("Z:\\TEMPLATES\\TERCEIROS\\sql-paises-estados-cidades-master\\estado.json"))
            {
                string json = r.ReadToEnd();
                _states = JsonSerializer.Deserialize<List<State>>(json);
            }

            List<Country> _countries = new List<Country>();
            using (StreamReader r = new StreamReader("Z:\\TEMPLATES\\TERCEIROS\\sql-paises-estados-cidades-master\\pais.json"))
            {
                string json = r.ReadToEnd();
                _countries = JsonSerializer.Deserialize<List<Country>>(json);
            }

            Address[] _address = new[]
            {
                new Address { Id = 1, Street = "1971", Number = "36", District = "Centro", PostalCode = "88390000", CountryId = 1, StateId = 24, CityId = 4444, IsActive = true }
            };

            Company[] _company = new[]
            {
                new Company { Id = 1, Name = "Genérico",  BusinessName = "Genérico", PhoneCode = "47", PhoneNumber = "999002349", Email = "isaacestudo1999@gmail.com", AddressId = 1, IsActive = true }
            };

            BusinessUnit[] _businessUnit = new[]
            {
                new BusinessUnit { Id = 1, CompanyId = 1, IsActive = true }
            };

            Contact[] _contact = new[]
            {
                new Contact { Id = 1, Name = "Genérico", CompanyId = 1, Nickname = "Genérico", PhoneCode = "47", PhoneNumber = "999002349", Email = "isaacestudo1999@gmail.com", AddressId = 1, IsActive = true }
            };

            Stage[] _stage = new[]
            {
                new Stage { Id = 1, Name = "Oportunidade", IsActive = true },
                new Stage { Id = 2, Name = "Negociação", IsActive = true },
                new Stage { Id = 3, Name = "Análise", IsActive = true },
                new Stage { Id = 4, Name = "Produção", IsActive = true },
                new Stage { Id = 5, Name = "Finalizada", IsActive = true },
                new Stage { Id = 6, Name = "Cancelada", IsActive = true }
            };

            Concept[] _concept = new[]
            {
                new Concept { Id = 1, Name = "Redes sociais", IsActive = true },
                new Concept { Id = 2, Name = "Em campo", IsActive = true },
                new Concept { Id = 3, Name = "Email", IsActive = true },
                new Concept { Id = 4, Name = "Telefonema", IsActive = true }
            };

            OpportunityType[] _opportunityType = new[]
            {
                new OpportunityType { Id = 1, Name = "Lead", IsActive = true },
                new OpportunityType { Id = 2, Name = "Venda", IsActive = true },
                new OpportunityType { Id = 3, Name = "Re-venda", IsActive = true },
                new OpportunityType { Id = 4, Name = "Recaptação", IsActive = true },
            };

            Opportunity[] _opportunity = new[]
            {
                new Opportunity { Id = 1, Description = "Genérica", NextRelationshipDate = DateTime.Now.AddDays(100), ValidityDate = DateTime.Now.AddMonths(12), ForecastDate = DateTime.Now.AddDays(200), PhoneCode = "47", PhoneNumber = "999002349", Email = "isaacestudo1999@gmail.com", ConceptId = 1, OpportunityTypeId = 1, UserId = 1, StageId = 1, OrderId = 1, CompanyId = 1, ContactId = 1, CreatedUser = 1,  IsActive = true }
            };

            OrderProduct[] _orderProduct = new[]
            {
                new OrderProduct { Id = 1, ProductId = 1, Quantity = 2, OrderId = 1, Price = 232.34, CreatedUser = 1,  IsActive = true }
            };

            Order[] _order = new[]
            {
                new Order { Id = 1, CreatedUser = 1,  IsActive = true }
            };

            modelBuilder.Entity<Module>().HasData(_modules);
            modelBuilder.Entity<ModuleItem>().HasData(_moduleItems);
            modelBuilder.Entity<ModuleMenu>().HasData(_moduleMenus);
            modelBuilder.Entity<Profile>().HasData(_profiles);
            modelBuilder.Entity<Users>().HasData(_users);
            modelBuilder.Entity<ModuleProfile>().HasData(_moduleProfiles);
            modelBuilder.Entity<City>().HasData(_cities);
            modelBuilder.Entity<State>().HasData(_states);
            modelBuilder.Entity<Country>().HasData(_countries);
            modelBuilder.Entity<InventoryType>().HasData(_inventoryType);
            modelBuilder.Entity<ProductCategory>().HasData(_productCategory);
            modelBuilder.Entity<ProductSubCategory>().HasData(_productSubCategory);
            modelBuilder.Entity<Product>().HasData(_product);
            modelBuilder.Entity<ProductStatus>().HasData(_productStatus);
            modelBuilder.Entity<Inventory>().HasData(_inventory);
            modelBuilder.Entity<InventoryItem>().HasData(_inventoryItem);
            modelBuilder.Entity<Address>().HasData(_address);
            modelBuilder.Entity<Company>().HasData(_company);
            modelBuilder.Entity<BusinessUnit>().HasData(_businessUnit);
            modelBuilder.Entity<Contact>().HasData(_contact);
            modelBuilder.Entity<Stage>().HasData(_stage);
            modelBuilder.Entity<Concept>().HasData(_concept);
            modelBuilder.Entity<OpportunityType>().HasData(_opportunityType);
            modelBuilder.Entity<Opportunity>().HasData(_opportunity);
            modelBuilder.Entity<OrderProduct>().HasData(_orderProduct);
            modelBuilder.Entity<Order>().HasData(_order);

            
        }

        private ModelBuilder ApplyGlobalStandards(ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade).ToList()
                    .ForEach(fe => fe.DeleteBehavior = DeleteBehavior.Restrict);

                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.UpdatedData):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.CreatedDate):
                            property.IsNullable = false;
                            property.SetColumnType("datetime");
                            property.SetDefaultValueSql("CURRENT_TIMESTAMP");
                            break;
                        case nameof(Entity.IsActive):
                            property.IsNullable = false;
                            property.SetDefaultValue(true);
                            break;
                    }
                }
            }

            return builder;
        }
    }
}

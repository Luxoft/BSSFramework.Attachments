﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AttachmentsSampleSystem.BLL
{
    
    
    public partial class BusinessUnitBLL : AttachmentsSampleSystem.BLL.SecurityDomainBLLBase<AttachmentsSampleSystem.Domain.BusinessUnit, Framework.DomainDriven.BLL.BLLBaseOperation>, AttachmentsSampleSystem.BLL.IBusinessUnitBLL
    {
        
		partial void Initialize();
        
        public BusinessUnitBLL(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context, Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.BusinessUnit> securityProvider, nuSpec.Abstraction.ISpecificationEvaluator specificationEvaluator = null) : 
                base(context, securityProvider, specificationEvaluator)
        {
            this.Initialize();
        }
    }
    
    public partial class BusinessUnitBLLFactory : Framework.DomainDriven.BLL.Security.SecurityBLLFactory<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.BLL.IBusinessUnitBLL, AttachmentsSampleSystem.BLL.BusinessUnitBLL, AttachmentsSampleSystem.Domain.BusinessUnit, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode>, AttachmentsSampleSystem.BLL.IBusinessUnitBLLFactory
    {
        
        public BusinessUnitBLLFactory(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
    }
    
    public partial class EmployeeBLL : AttachmentsSampleSystem.BLL.SecurityDomainBLLBase<AttachmentsSampleSystem.Domain.Employee, Framework.DomainDriven.BLL.BLLBaseOperation>, AttachmentsSampleSystem.BLL.IEmployeeBLL
    {
        
		partial void Initialize();
        
        public EmployeeBLL(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context, Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.Employee> securityProvider, nuSpec.Abstraction.ISpecificationEvaluator specificationEvaluator = null) : 
                base(context, securityProvider, specificationEvaluator)
        {
            this.Initialize();
        }
    }
    
    public partial class EmployeeBLLFactory : Framework.DomainDriven.BLL.Security.SecurityBLLFactory<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.BLL.IEmployeeBLL, AttachmentsSampleSystem.BLL.EmployeeBLL, AttachmentsSampleSystem.Domain.Employee, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode>, AttachmentsSampleSystem.BLL.IEmployeeBLLFactory
    {
        
        public EmployeeBLLFactory(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
    }
    
    public partial class HRDepartmentBLL : AttachmentsSampleSystem.BLL.SecurityDomainBLLBase<AttachmentsSampleSystem.Domain.HRDepartment, Framework.DomainDriven.BLL.BLLBaseOperation>, AttachmentsSampleSystem.BLL.IHRDepartmentBLL
    {
        
		partial void Initialize();
        
        public HRDepartmentBLL(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context, Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.HRDepartment> securityProvider, nuSpec.Abstraction.ISpecificationEvaluator specificationEvaluator = null) : 
                base(context, securityProvider, specificationEvaluator)
        {
            this.Initialize();
        }
    }
    
    public partial class HRDepartmentBLLFactory : Framework.DomainDriven.BLL.Security.SecurityBLLFactory<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.BLL.IHRDepartmentBLL, AttachmentsSampleSystem.BLL.HRDepartmentBLL, AttachmentsSampleSystem.Domain.HRDepartment, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode>, AttachmentsSampleSystem.BLL.IHRDepartmentBLLFactory
    {
        
        public HRDepartmentBLLFactory(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
    }
    
    public partial class LocationBLL : AttachmentsSampleSystem.BLL.SecurityDomainBLLBase<AttachmentsSampleSystem.Domain.Location, Framework.DomainDriven.BLL.BLLBaseOperation>, AttachmentsSampleSystem.BLL.ILocationBLL
    {
        
		partial void Initialize();
        
        public LocationBLL(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context, Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.Location> securityProvider, nuSpec.Abstraction.ISpecificationEvaluator specificationEvaluator = null) : 
                base(context, securityProvider, specificationEvaluator)
        {
            this.Initialize();
        }
    }
    
    public partial class LocationBLLFactory : Framework.DomainDriven.BLL.Security.SecurityBLLFactory<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.BLL.ILocationBLL, AttachmentsSampleSystem.BLL.LocationBLL, AttachmentsSampleSystem.Domain.Location, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode>, AttachmentsSampleSystem.BLL.ILocationBLLFactory
    {
        
        public LocationBLLFactory(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
    }
    
    public partial class NamedLockBLL : AttachmentsSampleSystem.BLL.SecurityDomainBLLBase<AttachmentsSampleSystem.Domain.NamedLock, Framework.DomainDriven.BLL.BLLBaseOperation>, AttachmentsSampleSystem.BLL.INamedLockBLL
    {
        
		partial void Initialize();
        
        public NamedLockBLL(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context, Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.NamedLock> securityProvider, nuSpec.Abstraction.ISpecificationEvaluator specificationEvaluator = null) : 
                base(context, securityProvider, specificationEvaluator)
        {
            this.Initialize();
        }
    }
    
    public partial class NamedLockBLLFactory : Framework.DomainDriven.BLL.Security.BLLFactoryBase<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.BLL.INamedLockBLL, AttachmentsSampleSystem.BLL.NamedLockBLL, AttachmentsSampleSystem.Domain.NamedLock>, AttachmentsSampleSystem.BLL.INamedLockBLLFactory
    {
        
        public NamedLockBLLFactory(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
    }
    
    public partial class AttachmentsSampleSystemBLLFactoryContainer : Framework.DomainDriven.BLL.BLLContextContainer<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext>, AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLFactoryContainer
    {
        
        private AttachmentsSampleSystem.BLL.IBusinessUnitBLL businessUnitBLL;
        
        private AttachmentsSampleSystem.BLL.AttachmentsSampleSystemDefaultBLLFactory defaultBLLFactory;
        
        private AttachmentsSampleSystem.BLL.IEmployeeBLL employeeBLL;
        
        private AttachmentsSampleSystem.BLL.IHRDepartmentBLL hRDepartmentBLL;
        
        private AttachmentsSampleSystem.BLL.AttachmentsSampleSystemImplementedBLLFactory implementedBLLFactory;
        
        private AttachmentsSampleSystem.BLL.ILocationBLL locationBLL;
        
        private AttachmentsSampleSystem.BLL.INamedLockBLL namedLockBLL;
        
        public AttachmentsSampleSystemBLLFactoryContainer(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
        
        public AttachmentsSampleSystem.BLL.IBusinessUnitBLL BusinessUnit
        {
            get
            {
                if (object.ReferenceEquals(this.businessUnitBLL, null))
                {
                    this.businessUnitBLL = this.BusinessUnitFactory.Create();
                }
                return this.businessUnitBLL;
            }
        }
        
        public AttachmentsSampleSystem.BLL.IBusinessUnitBLLFactory BusinessUnitFactory
        {
            get
            {
                return Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<AttachmentsSampleSystem.BLL.IBusinessUnitBLLFactory>(this.Context.ServiceProvider);
            }
        }
        
        public Framework.DomainDriven.BLL.Security.IDefaultSecurityBLLFactory<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode, System.Guid> Default
        {
            get
            {
                if (object.ReferenceEquals(this.defaultBLLFactory, null))
                {
                    this.defaultBLLFactory = new AttachmentsSampleSystem.BLL.AttachmentsSampleSystemDefaultBLLFactory(this.Context);
                }
                return this.defaultBLLFactory;
            }
        }
        
        public AttachmentsSampleSystem.BLL.IEmployeeBLL Employee
        {
            get
            {
                if (object.ReferenceEquals(this.employeeBLL, null))
                {
                    this.employeeBLL = this.EmployeeFactory.Create();
                }
                return this.employeeBLL;
            }
        }
        
        public AttachmentsSampleSystem.BLL.IEmployeeBLLFactory EmployeeFactory
        {
            get
            {
                return Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<AttachmentsSampleSystem.BLL.IEmployeeBLLFactory>(this.Context.ServiceProvider);
            }
        }
        
        public AttachmentsSampleSystem.BLL.IHRDepartmentBLL HRDepartment
        {
            get
            {
                if (object.ReferenceEquals(this.hRDepartmentBLL, null))
                {
                    this.hRDepartmentBLL = this.HRDepartmentFactory.Create();
                }
                return this.hRDepartmentBLL;
            }
        }
        
        public AttachmentsSampleSystem.BLL.IHRDepartmentBLLFactory HRDepartmentFactory
        {
            get
            {
                return Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<AttachmentsSampleSystem.BLL.IHRDepartmentBLLFactory>(this.Context.ServiceProvider);
            }
        }
        
        public Framework.DomainDriven.BLL.Security.IDefaultSecurityBLLFactory<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode, System.Guid> Implemented
        {
            get
            {
                if (object.ReferenceEquals(this.implementedBLLFactory, null))
                {
                    this.implementedBLLFactory = new AttachmentsSampleSystem.BLL.AttachmentsSampleSystemImplementedBLLFactory(this.Context);
                }
                return this.implementedBLLFactory;
            }
        }
        
        public AttachmentsSampleSystem.BLL.ILocationBLL Location
        {
            get
            {
                if (object.ReferenceEquals(this.locationBLL, null))
                {
                    this.locationBLL = this.LocationFactory.Create();
                }
                return this.locationBLL;
            }
        }
        
        public AttachmentsSampleSystem.BLL.ILocationBLLFactory LocationFactory
        {
            get
            {
                return Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<AttachmentsSampleSystem.BLL.ILocationBLLFactory>(this.Context.ServiceProvider);
            }
        }
        
        public AttachmentsSampleSystem.BLL.INamedLockBLL NamedLock
        {
            get
            {
                if (object.ReferenceEquals(this.namedLockBLL, null))
                {
                    this.namedLockBLL = this.NamedLockFactory.Create();
                }
                return this.namedLockBLL;
            }
        }
        
        public AttachmentsSampleSystem.BLL.INamedLockBLLFactory NamedLockFactory
        {
            get
            {
                return Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<AttachmentsSampleSystem.BLL.INamedLockBLLFactory>(this.Context.ServiceProvider);
            }
        }
        
        public static void RegisterBLLFactory(Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
        {
            Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<AttachmentsSampleSystem.BLL.IBusinessUnitBLLFactory, AttachmentsSampleSystem.BLL.BusinessUnitBLLFactory>(serviceCollection);
            Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<AttachmentsSampleSystem.BLL.IEmployeeBLLFactory, AttachmentsSampleSystem.BLL.EmployeeBLLFactory>(serviceCollection);
            Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<AttachmentsSampleSystem.BLL.IHRDepartmentBLLFactory, AttachmentsSampleSystem.BLL.HRDepartmentBLLFactory>(serviceCollection);
            Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<AttachmentsSampleSystem.BLL.ILocationBLLFactory, AttachmentsSampleSystem.BLL.LocationBLLFactory>(serviceCollection);
            Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<AttachmentsSampleSystem.BLL.INamedLockBLLFactory, AttachmentsSampleSystem.BLL.NamedLockBLLFactory>(serviceCollection);
        }
    }
    
    public partial class AttachmentsSampleSystemDefaultBLLFactory : Framework.DomainDriven.BLL.Security.DefaultSecurityBLLFactory<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, AttachmentsSampleSystem.Domain.DomainObjectBase, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode, System.Guid>, Framework.DomainDriven.BLL.Security.IDefaultSecurityBLLFactory<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode, System.Guid>
    {
        
        public AttachmentsSampleSystemDefaultBLLFactory(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
        
        public override Framework.DomainDriven.BLL.IDefaultDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid> Create<TDomainObject>()
        {
            return new AttachmentsSampleSystem.BLL.DomainBLLBase<TDomainObject>(this.Context);
        }
    }
    
    public partial class AttachmentsSampleSystemImplementedBLLFactory : Framework.DomainDriven.BLL.Security.DefaultSecurityBLLFactory<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, AttachmentsSampleSystem.Domain.DomainObjectBase, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode, System.Guid>, Framework.DomainDriven.BLL.Security.IDefaultSecurityBLLFactory<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode, System.Guid>
    {
        
        public AttachmentsSampleSystemImplementedBLLFactory(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
        
        public override Framework.DomainDriven.BLL.IDefaultDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid> Create<TDomainObject>()
        {
            if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.BusinessUnit)))
            {
                return ((Framework.DomainDriven.BLL.IDefaultDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.BusinessUnit));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.Employee)))
            {
                return ((Framework.DomainDriven.BLL.IDefaultDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.Employee));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.HRDepartment)))
            {
                return ((Framework.DomainDriven.BLL.IDefaultDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.HRDepartment));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.Location)))
            {
                return ((Framework.DomainDriven.BLL.IDefaultDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.Location));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.NamedLock)))
            {
                return ((Framework.DomainDriven.BLL.IDefaultDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.NamedLock));
            }
            else
            {
                return new AttachmentsSampleSystem.BLL.DomainBLLBase<TDomainObject>(this.Context);
            }
        }
        
        public override Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid> Create<TDomainObject>(Framework.SecuritySystem.ISecurityProvider<TDomainObject> securityProvider)
        {
            if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.BusinessUnit)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.BusinessUnitFactory.Create(((Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.BusinessUnit>)(securityProvider)))));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.Employee)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.EmployeeFactory.Create(((Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.Employee>)(securityProvider)))));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.HRDepartment)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.HRDepartmentFactory.Create(((Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.HRDepartment>)(securityProvider)))));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.Location)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.LocationFactory.Create(((Framework.SecuritySystem.ISecurityProvider<AttachmentsSampleSystem.Domain.Location>)(securityProvider)))));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.NamedLock)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.NamedLockFactory.Create()));
            }
            else
            {
                return new AttachmentsSampleSystem.BLL.SecurityDomainBLLBase<TDomainObject>(this.Context);
            }
        }
        
        public override Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid> Create<TDomainObject>(AttachmentsSampleSystem.AttachmentsSampleSystemSecurityOperationCode securityOperation)
        {
            if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.BusinessUnit)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.BusinessUnitFactory.Create(securityOperation)));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.Employee)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.EmployeeFactory.Create(securityOperation)));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.HRDepartment)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.HRDepartmentFactory.Create(securityOperation)));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.Location)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.LocationFactory.Create(securityOperation)));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.NamedLock)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.NamedLockFactory.Create()));
            }
            else
            {
                return new AttachmentsSampleSystem.BLL.SecurityDomainBLLBase<TDomainObject>(this.Context);
            }
        }
        
        public override Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid> Create<TDomainObject>(Framework.SecuritySystem.BLLSecurityMode bllSecurityMode)
        {
            if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.BusinessUnit)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.BusinessUnitFactory.Create(bllSecurityMode)));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.Employee)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.EmployeeFactory.Create(bllSecurityMode)));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.HRDepartment)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.HRDepartmentFactory.Create(bllSecurityMode)));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.Location)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.LocationFactory.Create(bllSecurityMode)));
            }
            else if ((typeof(TDomainObject) == typeof(AttachmentsSampleSystem.Domain.NamedLock)))
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(this.Context.Logics.NamedLockFactory.Create()));
            }
            else
            {
                return ((Framework.DomainDriven.BLL.Security.IDefaultSecurityDomainBLLBase<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, TDomainObject, System.Guid>)(new AttachmentsSampleSystem.BLL.SecurityDomainBLLBase<TDomainObject>(this.Context)));
            }
        }
    }
}
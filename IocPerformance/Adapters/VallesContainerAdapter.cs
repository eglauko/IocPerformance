using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valles.Inject.AspNetCore;

namespace IocPerformance.Adapters
{
    public class VallesContainerAdapter : ContainerAdapterBase
    {
        private Valles.Inject.Core.Container container;

        private Valles.Inject.Core.IInjector injector;

        public override string PackageName => "Valles.Inject";

        public override string Version => "1.0-preview2";

        public override string Name => "Valles";

        public override string Url => "https://happycenter.visualstudio.com/Vaalles.Inject";

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportAspNetCore => true;

        public override bool SupportsPropertyInjection => false;

        public override object Resolve(Type type) => this.injector.Resolve(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            //injector?.Resolve<Valles.Inject.Core.IScope>().Dispose();
        }

        public override void Prepare()
        {
            container = new Valles.Inject.Core.Container();
            container.AddSupportToServiceProvider();
            container.AddServiceCollection(CreateServiceCollection());

            this.RegisterBasic();
            this.RegisterOpenGeneric();
            this.RegisterMultiple();

            this.injector = container.InitializeInjector();
        }

        public override void PrepareBasic()
        {
            container = new Valles.Inject.Core.Container();
            //container.AddSupportToServiceProvider();
            //container.AddServiceCollection(CreateServiceCollection());

            this.RegisterBasic();

            this.injector = container.InitializeInjector();
        }

        private void RegisterBasic()
        {
            this.RegisterDummies();
            this.RegisterStandard();
            this.RegisterComplex();
        }

        private void RegisterDummies()
        {
            this.container.AddTransient<IDummyOne, DummyOne>();
            this.container.AddTransient<IDummyTwo, DummyTwo>();
            this.container.AddTransient<IDummyThree, DummyThree>();
            this.container.AddTransient<IDummyFour, DummyFour>();
            this.container.AddTransient<IDummyFive, DummyFive>();
            this.container.AddTransient<IDummySix, DummySix>();
            this.container.AddTransient<IDummySeven, DummySeven>();
            this.container.AddTransient<IDummyEight, DummyEight>();
            this.container.AddTransient<IDummyNine, DummyNine>();
            this.container.AddTransient<IDummyTen, DummyTen>();
        }

        private void RegisterStandard()
        {
            this.container.AddSingleton<ISingleton1, Singleton1>();
            this.container.AddSingleton<ISingleton2, Singleton2>();
            this.container.AddSingleton<ISingleton3, Singleton3>();
            this.container.AddTransient<ITransient1, Transient1>();
            this.container.AddTransient<ITransient2, Transient2>();
            this.container.AddTransient<ITransient3, Transient3>();
            this.container.AddTransient<ICombined1, Combined1>();
            this.container.AddTransient<ICombined2, Combined2>();
            this.container.AddTransient<ICombined3, Combined3>();
            this.container.AddTransient<ICalculator1, Calculator1>();
            this.container.AddTransient<ICalculator2, Calculator2>();
            this.container.AddTransient<ICalculator3, Calculator3>();
        }

        private void RegisterComplex()
        {
            this.container.AddTransient<ISubObjectOne, SubObjectOne>();
            this.container.AddTransient<ISubObjectTwo, SubObjectTwo>();
            this.container.AddTransient<ISubObjectThree, SubObjectThree>();
            this.container.AddSingleton<IFirstService, FirstService>();
            this.container.AddSingleton<ISecondService, SecondService>();
            this.container.AddSingleton<IThirdService, ThirdService>();
            this.container.AddTransient<IComplex1, Complex1>();
            this.container.AddTransient<IComplex2, Complex2>();
            this.container.AddTransient<IComplex3, Complex3>();
        }

        private void RegisterOpenGeneric()
        {
            this.container.AddTransient(typeof(IGenericInterface<>), typeof(GenericExport<>));
            this.container.AddTransient(typeof(ImportGeneric<>), typeof(ImportGeneric<>));
        }

        private void RegisterMultiple()
        {
            this.container.AddTransient<ImportMultiple1>();
            this.container.AddTransient<ImportMultiple2>();
            this.container.AddTransient<ImportMultiple3>();
            this.container.AddTransient<ISimpleAdapter, SimpleAdapterOne>();
            this.container.AddTransient<ISimpleAdapter, SimpleAdapterTwo>();
            this.container.AddTransient<ISimpleAdapter, SimpleAdapterThree>();
            this.container.AddTransient<ISimpleAdapter, SimpleAdapterFour>();
            this.container.AddTransient<ISimpleAdapter, SimpleAdapterFive>();
        }
    }
}

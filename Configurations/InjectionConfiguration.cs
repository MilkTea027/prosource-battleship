using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using ProSource.Robles.Battleship.EnemyShip.Steps;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipHide.Steps;
using ProSource.Robles.Battleship.ShipPlacement.ShipHide.Steps.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps.Interfaces;

namespace ProSource.Robles.Battleship.Configurations
{
    public static class InjectionConfiguration
    {
        /// <summary>
        /// Builds the inversion of controls.
        /// </summary>
        public static ServiceProvider GetBuiltConfiguredServices()
        {
            var services = new ServiceCollection();

            services.RegisterAssemblyPublicNonGenericClasses()
                    .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            RegisterServicesWithAbstractParents(services);

            return services.BuildServiceProvider();
        }

        private static void RegisterServicesWithAbstractParents(IServiceCollection services)
        {
            RegisterShipPlacementSteps(services);
            RegisterEnemyShipSteps(services);
        }

        public static void RegisterShipPlacementSteps(IServiceCollection services)
        {
            //// SHIP DISPLAY STEPS
            services.AddScoped<IOutOfBoundsCheckStep, OutOfBoundsCheckStep>();
            services.AddScoped<IShipOverlapCheckStep, ShipOverlapCheckStep>();
            services.AddScoped<IValidShipDisplayStep, ValidShipDisplayStep>();

            //// SHIP HIDE STEPS
            services.AddScoped<IValidHideShipStep, ValidHideShipStep>();

            //// SHIP PLACE STEPS
            services.AddScoped<IAllShipAddedCheckStep, AllShipAddedCheckStep>();
            services.AddScoped<IPendingDisplayShipCheckStep, PendingDisplayShipCheckStep>();
            services.AddScoped<IPlaceEnemyShipStep, PlaceEnemyShipStep>();
            services.AddScoped<IValidShipPlaceStep, ValidShipPlaceStep>();
        }

        public static void RegisterEnemyShipSteps(IServiceCollection services)
        {
            services.AddScoped<IShowEnemyShipProgressStep, ShowEnemyShipProgressStep>();
            services.AddScoped<IRetrieveAllShipButtonStep, RetrieveAllShipButtonStep>();
            services.AddScoped<IPlaceEnemyDestroyerShipStep, PlaceEnemyDestroyerShipStep>();
            services.AddScoped<IPlaceEnemySubmarineShipStep, PlaceEnemySubmarineShipStep>();
            services.AddScoped<IPlaceEnemyCruiserShipStep, PlaceEnemyCruiserShipStep>();
            services.AddScoped<IPlaceEnemyBattleshipShipStep, PlaceEnemyBattleshipShipStep>();
            services.AddScoped<IPlaceCarrierShipStep, PlaceCarrierShipStep>();
            services.AddScoped<IEnemyAttackStartStep, EnemyAttackStartStep>();
        }
    }
}
// import FuelCalc from './FuelCalc';
const FuelCalc = require('./FuelCalc');

const getResults = async () => {
    const fc = new FuelCalc();
    await fc.readInMassInputs();

    const result = fc.calculateAllFuelNeeds();
    console.log(result);

    const requiredFuel = fc.calculateRequiredFuel();
    console.log(requiredFuel);
}

getResults();
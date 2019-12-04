const fs = require('fs');
const readline = require('readline');

class FuelCalc {

    constructor() {
        this.masses = [];
        this.requiredFuel = [];
        this.path = './mass-inputs-for-day-1.txt';
    }

    async readInMassInputs(path) {
        const filestream = fs.createReadStream(path || this.path);
        const rl = readline.createInterface({ input: filestream, crlfDelay: Infinity });

        for await (const line of rl) {
            if (line !== undefined)
                this.masses.push(parseInt(line));
            else
                return;
        }
    }

    getRequiredFuelAmount(mass) {
        return Math.floor((mass / 3)) - 2;
    }

    calculateAllFuelNeeds() {
        let total = 0;

        for (const mass in this.masses) {
            total = total + this.getRequiredFuelAmount(parseInt(this.masses[mass]));
        }

        return total;
    }

    calculateRequiredFuel() {
        let currentFuelNeeds = 0;

        for (const mass in this.masses) {
            let current = this.masses[mass];
            while (this.getRequiredFuelAmount(current) >= 0) {
                current = this.getRequiredFuelAmount(current);
                currentFuelNeeds += parseInt(current);
            }
        }

        return currentFuelNeeds;
    }
}

module.exports = FuelCalc;
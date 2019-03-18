export class RentedCars {

    public constructor (
    
        public id?: number,
        public carid?: number,
        public licenseplate?: string,
        public start?: Date,
        public returndate?: Date,
        public actualreturn?: Date,
        public userid?: number,
        public fullname?: string,
        public username?: string,
        public idnumber?: string,
        public email?: string,
        public description?: string,
        public dailycost?: number,
        public dailydelaycost?: number,
        
        
    ) {}
}
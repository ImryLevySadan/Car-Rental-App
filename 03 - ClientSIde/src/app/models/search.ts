export class Search {

    public constructor (
        public typeid?: number,
        public rentid? : number,
        public carid? : number,
        public start?: Date,
        public returndate?: Date,
        public manufacture?: string,
        public model?: string,
        public licenseplate?: string,
        public year?: number,
        public transmission?: string, 
        public dailycost?: number,
        public dailydelaycost?: number,
        public Address?: string,
        public Longitude?: number,
        public Latitude?: number


    ) {}
}
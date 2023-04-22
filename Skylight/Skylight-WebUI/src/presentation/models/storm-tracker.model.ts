// import { BaseModel } from './index';
// import { IStormTracker as IStormTrackerWebModel } from 'web/web-models';

// export interface IStormTracker extends IStormTrackerWebModel {
//   // Add any Presentation Layer data fields here...
// }

// export class StormTracker extends BaseModel implements IStormTracker {
//   public firstName: string;
//   public lastName: string;
//   public startDate: Date;
//   public biography?: string;
//   public picturePath?: string;

//   constructor(data?: IStormTracker) {
//     super(data);
    
//     this.firstName = this.str(data, 'firstName');
//     this.lastName = this.str(data, 'lastName');
//     this.startDate = this.date(data, 'startDate');
//     this.biography = data?.biography;
//     this.picturePath = data?.picturePath;
//   }
// }

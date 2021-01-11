import { DatePipe } from "@angular/common";

export class Cropbidding{
    BiddingId: number;
    RequestId:number;
	BidderId:number;
	InitialPrice:number;
	CurrentBidPrice:number;
	PreviousBidPrice:number; 
	BidCloseTime:DatePipe;
	ApprovalAdminId:number;

}


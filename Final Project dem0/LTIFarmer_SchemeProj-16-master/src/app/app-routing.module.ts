import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';
import { AboutUsComponent } from './about-us/about-us.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { BidderHomeComponent } from './bidder-home/bidder-home.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { FarmerHomeComponent } from './farmer-home/farmer-home.component';
import { LoginComponent } from './login/login.component';
import { MainHomeComponent } from './main-home/main-home.component';
import { ViewMessageComponent } from './view-message/view-message.component';
import { AdminApproveFarmerComponent } from './admin-approve-farmer/admin-approve-farmer.component';
import { AdminApproveBidderComponent } from './admin-approve-bidder/admin-approve-bidder.component'
import { AdminApproveCropComponent } from './admin-approve-crop/admin-approve-crop.component';
import { AdminApproveClaimComponent } from './admin-approve-claim/admin-approve-claim.component';
import { SaleHistoryComponent } from './sale-history/sale-history.component';
import { MarketplaceBidderComponent } from './marketplace-bidder/marketplace-bidder.component';
import { BidderAuctionComponent } from './bidder-auction/bidder-auction.component';

import { FarmerRegComponent } from './farmer-reg/farmer-reg.component';
import { BidderRegComponent } from './bidder-reg/bidder-reg.component';
import { RegistrationDashboardComponent } from './registration-dashboard/registration-dashboard.component';
import { InsuranceApplicationComponent } from './insurance-application/insurance-application.component';

import {ClaiminsuranceComponent} from './claiminsurance/claiminsurance.component';
import{CroprequestComponent} from'./croprequest/croprequest.component';
import{FarmermarketComponent} from './farmermarket/farmermarket.component';


import { AdminApproveAuctionComponent } from './admin-approve-auction/admin-approve-auction.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { HomeFaqComponent } from './home-faq/home-faq.component';



const routerOptions: ExtraOptions = {
  scrollPositionRestoration: 'enabled',
  anchorScrolling: 'enabled',
  scrollOffset: [0, 64],
};

const routes: Routes = [
  {path:"Home",component:MainHomeComponent},
  {path:"Aboutus",component:AboutUsComponent},
  {path:"Contactus",component:ContactUsComponent},
  {path:"Login",component:LoginComponent},
  {path:"AdminHome",component:AdminHomeComponent},
  {path:"FarmerHome",component:FarmerHomeComponent},
  {path:"BidderHome",component:BidderHomeComponent},
  {path:"ViewMessage",component:ViewMessageComponent},
  {path:"ApproveFarmer",component:AdminApproveFarmerComponent},
  {path:"ApproveBidder",component:AdminApproveBidderComponent},
  {path:"ApproveCrop",component:AdminApproveCropComponent},  
  {path:"ApproveClaim",component:AdminApproveClaimComponent},  
  {path:"SaleHistory",component:SaleHistoryComponent},
  {path:"BidderMarketplace",component:MarketplaceBidderComponent},
  {path:"AuctionPage",component:BidderAuctionComponent},
  {path:"FarmerRegistration",component:FarmerRegComponent},
  {path:"BidderRegistration",component:BidderRegComponent},
  {path:"RegistrationDashboard",component:RegistrationDashboardComponent},
  {path:"InsuranceApply",component:InsuranceApplicationComponent},
  {path:"InsuranceClaim",component:ClaiminsuranceComponent},
  {path:"ListCrop",component:CroprequestComponent},
  {path:"MarketFarmer",component:FarmermarketComponent},
  {path:"ApproveAuction",component:AdminApproveAuctionComponent},
  {path:"ForgotPasswordComponent",component:ForgotPasswordComponent},
  {path:"FAQ",component:HomeFaqComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes,routerOptions)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

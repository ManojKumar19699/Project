import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'

import { ReactiveFormsModule, FormControl} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { ContactService } from './services/contactService';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { MainHomeComponent } from './main-home/main-home.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { Router } from '@angular/router';
import { LoginService } from './services/loginService';
import { FarmerHomeComponent } from './farmer-home/farmer-home.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { BidderHomeComponent } from './bidder-home/bidder-home.component';
import { ViewMessageComponent } from './view-message/view-message.component';
import { AdminApproveFarmerComponent } from './admin-approve-farmer/admin-approve-farmer.component';
import {AdminApproveFarmerService} from './services/admin-approve-farmer.service';
import { AdminApproveBidderComponent } from './admin-approve-bidder/admin-approve-bidder.component'
import { AdminApproveBidderService } from './services/admin-approve-bidder.service';
import { AdminApproveCropComponent } from './admin-approve-crop/admin-approve-crop.component';
import {AdminApproveCropService} from './services/admin-approve-crop.service';
import { AdminApproveClaimComponent } from './admin-approve-claim/admin-approve-claim.component';
import {AdminApproveClaimService} from './services/admin-approve-claim.service';
import { MailService } from './services/MailService';
import { SaleHistoryComponent } from './sale-history/sale-history.component';
import { SaleHistoryService } from './services/salehistoryService';
import { MarketplaceBidderComponent } from './marketplace-bidder/marketplace-bidder.component';
import {BidderMarketPlaceService} from './services/bidder-marketplace.service';
import { BidderAuctionComponent } from './bidder-auction/bidder-auction.component';
import { FarmerRegComponent } from './farmer-reg/farmer-reg.component';
import { BidderRegComponent } from './bidder-reg/bidder-reg.component';

import { RegistrationDashboardComponent } from './registration-dashboard/registration-dashboard.component';
import { RequestService } from './services/farmerregservice';
import { InsuranceApplicationComponent } from './insurance-application/insurance-application.component';
import { BidderService } from './services/bidderregservice';
import { ValidateEqualModule } from 'ng-validate-equal';

import { ClaimRequestService } from './services/claimrequestservice';
import { CroprequestComponent } from './croprequest/croprequest.component';
import { CropRequestService } from './services/croprequestservice';
import { FarmermarketComponent } from './farmermarket/farmermarket.component';
import { FarmerMarketService } from './services/farmermarketservice';
import { ClaiminsuranceComponent } from './claiminsurance/claiminsurance.component';

import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ForgotserviceService } from './services/ForgetService'

import { AdminApproveAuctionComponent } from './admin-approve-auction/admin-approve-auction.component';
import {AdminApproveAuctionService} from './services/admin-approve-auction.service';
import { NgImageSliderModule } from 'ng-image-slider';
import { HomeFaqComponent } from './home-faq/home-faq.component';


@NgModule({
  declarations: [
     AppComponent,
     LoginComponent,
     MainHomeComponent,
     AboutUsComponent,
     ContactUsComponent,
     FarmerHomeComponent,
     AdminHomeComponent,
     BidderHomeComponent,
     ViewMessageComponent,
     AdminApproveFarmerComponent,
    AdminApproveBidderComponent,
    AdminApproveCropComponent,
    AdminApproveClaimComponent,
    SaleHistoryComponent,
    MarketplaceBidderComponent,
    BidderAuctionComponent,
    FarmerRegComponent,
    BidderRegComponent,
    RegistrationDashboardComponent,
    InsuranceApplicationComponent,
    ClaiminsuranceComponent,
    CroprequestComponent,
    FarmermarketComponent,
    AdminApproveAuctionComponent,
    ForgotPasswordComponent,
    HomeFaqComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ValidateEqualModule,
    ReactiveFormsModule,
    NgImageSliderModule,
  ],
  
  providers: [
    AdminApproveFarmerService,
    AdminApproveBidderService,
    AdminApproveCropService,
    AdminApproveClaimService,
    ContactService,
    LoginService,
    MailService,
    SaleHistoryService,
    BidderMarketPlaceService,
    RequestService,
    ClaimRequestService,
    FarmerMarketService,
    CropRequestService,
    BidderService,
    AdminApproveAuctionService,
    ForgotserviceService,
  ],
  bootstrap: [AppComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA]
})
export class AppModule {

  
 }

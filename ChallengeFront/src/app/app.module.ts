import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import {TableModule} from 'primeng/table';
import {ButtonModule} from 'primeng/button';
import {MatButtonModule, MatMenuModule, MatIconModule, MatCardModule} from '@angular/material';
import { AppComponent } from './app.component';
import {MessageService} from 'primeng/components/common/messageservice';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { appRoutes } from './routes';
import { UserComponent} from './Users/user.component';
import {UserService } from './Users/user.service';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes),
    TableModule,
    ButtonModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatCardModule
  ],
  providers: [UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ActiveTaskComponent } from './active-task/active-task.component';
import { PadComponent } from './pad/pad.component';
import { TaskDetailComponent } from './pad/task-detail/task-detail.component';
import { TaskEditorComponent } from './pad/task-editor/task-editor.component';
import { PanelComponent } from './panel/panel.component';
import { TaskPlaceholderComponent } from './pad/task-placeholder/task-placeholder.component';
import { PadService } from './shared/pad.service';
import { PageService } from './shared/page.service';
import { PadProviderService } from './shared/pad-provider.service';
import { PadProviderServiceMock } from './shared/pad-provider.service.mock';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';
import { PanelService } from './panel/panel.service';
import { AlertService } from './shared/alert/alert.service';
import { AlertComponent } from './shared/alert/alert.component';;
import { AuthComponent } from './auth/auth.component'

@NgModule({
    imports: [
        RouterModule,
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        PadComponent,
        ActiveTaskComponent,
        HeaderComponent,
        TaskDetailComponent,
        TaskEditorComponent,
        PanelComponent,
        TaskPlaceholderComponent,
        PageNotFoundComponent,
        AlertComponent,
        AuthComponent
    ],
    providers: [
        PadService,
        PadProviderService,
        PadProviderServiceMock,
        PageService,
        PanelService,
        AlertService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
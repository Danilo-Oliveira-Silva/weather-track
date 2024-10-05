import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MeasuresComponent } from './components/measures/measures.component';
import { LayoutComponent } from './components/layout/layout.component';
import { authGuard } from './services/auth.guard';
import { SignupComponent } from './components/signup/signup.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'signup',
        component: SignupComponent
    },
    {
        path: '',
        component: LayoutComponent,
        children: 
        [
            {
                path: 'measures',
                component: MeasuresComponent,
                canActivate: [authGuard]
            }
        ]
    }    

];

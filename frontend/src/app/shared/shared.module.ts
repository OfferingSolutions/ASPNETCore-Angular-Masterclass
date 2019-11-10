import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FooterComponent } from './components/footer/footer.component';
import { NavigationComponent } from './components/navigation/navigation.component';

@NgModule({
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  exports: [NavigationComponent, FooterComponent],
  declarations: [NavigationComponent, FooterComponent],
  providers: [],
})
export class SharedModule {}

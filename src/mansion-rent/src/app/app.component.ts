import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'mansion-rent';

  constructor(private toastr: ToastrService) {
    this.toastr.success('This is a success message', 'Tada');
  }
}

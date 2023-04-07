import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { MansionService } from 'src/app/services/mansion.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { IMansionApiResponse, IMansionResult } from 'src/assets/data/IMansionApiResonse';

@Component({
  selector: 'app-mansion-list',
  templateUrl: './mansion-list.component.html',
  styleUrls: ['./mansion-list.component.css']
})
export class MansionListComponent implements OnInit{
  mansionlist!: IMansionResult[];
  fullName: string = "";
  role: string = "";

  dropMansionList(mansion: IMansionResult) {
    this.mansionlist.filter(obj => obj.id !== mansion.id);
  }

  constructor(
    private mansionService: MansionService,
    private auth: AuthService,
    private userStore: UserStoreService) { 

  }

  ngOnInit(): void {
    this.mansionService.getAllMansions()
    .subscribe({
      next: (mansions) => {
        this.mansionlist = mansions.result;
        console.log(this.mansionlist);
      },
      error: (response) => {
        console.log(response)
      }
    });

    this.userStore.getFullNameFromStore()
      .subscribe(val => {
        const roleFromToken = this.auth.getRoleFromToken();
        this.role = val || roleFromToken;
        console.log(this.role);
      });
  } 
}



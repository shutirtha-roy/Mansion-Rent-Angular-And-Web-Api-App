import { Component, OnInit } from '@angular/core';
import { MansionService } from 'src/app/services/mansion.service';

@Component({
  selector: 'app-mansion-list',
  templateUrl: './mansion-list.component.html',
  styleUrls: ['./mansion-list.component.css']
})
export class MansionListComponent implements OnInit{
  mansions: any[] = [
  ];

  constructor(private mansionService: MansionService) { }

  ngOnInit(): void {
    this.mansionService.getAllMansions()
    .subscribe({
      next: (mansions) => {
        //console.log(employees);
        this.mansions = mansions;
        console.log(this.mansions);
      },
      error: (response) => {
        console.log(response)
      }
    });
}
}

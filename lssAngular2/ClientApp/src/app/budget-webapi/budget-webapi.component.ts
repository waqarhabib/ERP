import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-budget-webapi',
  templateUrl: './budget-webapi.component.html'
})



export class BudgetWebApiComponent {
  public budget: IBudgetView;
  public myString: string;

  constructor(
    http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    //this.myString = "Hello world";

    http.get<IBudgetView>(baseUrl + 'api/SampleData/Budget?budgetId=2').subscribe(result => {

      this.budget = result;
      this.myString = "Hello World";

    }, error => console.error(error));

    //this.getBudget();
  }
  /*
  getBudget() {
    this.http.get<IBudgetView>(this.baseUrl + 'api/SampleData/Budget?budgetId=2').subscribe(result => {

      this.budget = result;
      this.myString = "Hello World";

    }, error => console.error(error));

  }
  */
 }


interface IBudgetView {
  budgetId: number;
  budgetHours: number;
  budgetAmount: number;
  actualHours: number;
  actualAmount: number;
  accountId: number;
  accountDescription: string;
  companyNumber: string;
  busUnit: string;
  objectNumber: string;
  subsidiary: string;
  rangeId: number;
  rangeStartDate: Date;
  rRangeEndDate: Date;
  companyCode: string;
  supervisorCode: string;
  projectedHours: number;
  projectedAmount: number;
}
/*
export class BudgetView {
  budgetId: number;
  budgetHours: number;
  budgetAmount: number;
  actualHours: number;
  actualAmount: number;
  accountId: number;
  accountDescription: string;
  companyNumber: string;
  busUnit: string;
  objectNumber: string;
  subsidiary: string;
  rangeId: number;
  rangeStartDate: Date;
  rRangeEndDate: Date;
  companyCode: string;
  supervisorCode: string;
  projectedHours: number;
  projectedAmount: number;
}
*/


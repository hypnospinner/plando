import { Component, OnInit } from '@angular/core';
import {Laundry, User} from '@app/_models';
import {LaundryService, ManagerService} from '@app/_services';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-manager-binding',
  templateUrl: './manager-binding.component.html'
})
export class ManagerBindingComponent implements OnInit {
  freeManagers: User[];
  selectedEmployManager: User;
  laundries: Laundry[];
  selectedLaundry: Laundry;

  busyManagers: User[];
  selectedDismissManager: User[];

  dismissManagerForm: FormGroup;
  loading = false;
  errMess: string;
  constructor(private laundryService: LaundryService,
              private managerService: ManagerService,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.loading = true;
    this.managerService.getFreeManagers()
      .subscribe(managers => {
        this.freeManagers = managers;
        this.loading = false;
      }, errmess => this.errMess = errmess);
    this.laundryService.getAll()
      .subscribe(laundries => {
        this.laundries = laundries;
        this.loading = false;
      }, errmess => this.errMess = errmess);
    this.managerService.getBusyManagers()
      .subscribe(managers => {
        this.busyManagers = managers;
        this.loading = false;
      }, errmess => this.errMess = errmess);
    this.dismissManagerForm = this.formBuilder.group({
      dismissManagerSelect: ['', Validators.required],
    });
  }
  get dismissControls() { return this.dismissManagerForm.controls; }
  onSelectedDismissManagerChanged(){
    this.selectedDismissManager = this.dismissControls.dismissManagerSelect.value;
  }
  onDismissSubmit(){
    return;
  }
}

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {MenuItem} from 'primeng/api';
import { UserService} from './user.service';

@Component({
  selector: 'app-users',
  templateUrl: './user.component.html',
  styleUrls: []
})
export class UserComponent implements OnInit {
  users: any = [];

  constructor(private router: Router,
    private UsersService: UserService,
    private route: ActivatedRoute) { }

  ngOnInit() {

    this.UsersService.GetUsers().subscribe((data: any) => {      
      this.users = data;
    });

  }
}

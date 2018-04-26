import { Component } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { PercentPipe } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { TeamService } from '../../services/teamservice.service'
import { TeamData } from '../poll/poll.component'

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/zip';

@Component({
    templateUrl: './results.component.html',
})

export class ResultExp {

    public resultList: TeamData[];
    public totalVotes: number;
    public isvoted: boolean = false;

    constructor(public http: Http, private _teamService: TeamService) {

        Observable.zip(this._teamService.getTotalVotes(), this._teamService.getTeams()).subscribe(([totalVoteCount, teamListData]) => {
            this.totalVotes = totalVoteCount;
            this.resultList = teamListData;

            for (let i = 0; i < teamListData.length; i++) {
                teamListData[i].voteShare = (((teamListData[i].voteCount) / this.totalVotes) * 100);
            }
        });
    }
}
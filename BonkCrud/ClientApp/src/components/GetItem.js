import React, { Componenet } from 'react';
import axios from 'axios';
import Table from './Table';

export default class GetItem extends Componenet {
    constructor(props) {
        super(props);
        this.state = { items: [] };
    }

    componentDidMount() {
        debugger;
        axios.get('')
            .then(response => {
                this.setState({ item: response.data });
                debugger;
            })
            .catch(function (error) {
                console.log(error);
            })
    }

    tabRow() {
        return (
            <div>
                <h4 align="center">Item List</h4>
                <table className="table table-striped" style={{ marginTop: 10 }}>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Quantity</th>
                            <th colSpan="4">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.tabRow()}
                    </tbody>
                </table>
            </div>
        );
    }
}
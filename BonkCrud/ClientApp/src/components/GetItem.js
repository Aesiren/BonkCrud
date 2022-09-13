import React, { Component } from 'react';
import axios from 'axios';
import Table from './Table';
//import 'BonkCrud.model'

export class GetItem extends Component { 
    constructor(props) {
        super(props);
        this.state = { items: [] };
    }

    componentDidMount() {
        debugger;
        axios.get('https://localhost:44435/API/Item/ItemDetails/')
            .then(response => {
                this.setState({ items: response.data });
                debugger;
            })
            .catch(function (error) {
                console.log(error);
            })
    }

    tabRow() {
        return this.state.items.map(function (object, i) {
            return <Table obj={object} key={i} />
        });

}

    render(){ 
        return (
           <div>
                <h4 align="center">Item List</h4>
                <table className="table table-striped" style={{ marginTop: 10 }}>
                    <thead>
                        <tr>
                            <th>Item ID</th>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Quantity</th>
                            <th>Owning User</th>
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
//export default GetItem;
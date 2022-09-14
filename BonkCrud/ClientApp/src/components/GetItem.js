import React, { Component } from 'react';
import '../AddItem.css';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Table from './Table';
//import 'BonkCrud.Model'

export class GetItem extends Component {
    constructor(props) {
        super(props);
        this.state = { items: [] };
    }

    componentDidMount() {
        debugger;
        getItemList()
            .then(response => {
                this.setState({ items: response.json() });
                console.log(this.state.items.json());
                debugger;
            })
            .catch(function (error) {
                //console.log(error);
            })
    }

    tabRow() {
        return this.state.items.map(function (object, i) {
            return <Table obj={object} key={i} />
        });

    }

    render() {
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
async function getItemList() {
    console.log("Starting fetch");
    let response = await fetch('API/Item/ItemList');
    let data = await response.json();
    console.log("Fetch complete");
    return data;
}
   /* constructor() {
        super();
        this.state = { dbItems:[]};
    }

    
    componentDidMount() {

        getItemList().then(result => { this.setState({ dbItems: result.json() }) });

    }
    

    static renderItemsTable() {
        return (
              
            <table className='table table-striped' area-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Detail</th>
                        <th>Quantity</th>
                        <th>Owner</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.dbItems.map((itm) =>
                        <tr key={itm.ItemID}>
                            <td>{itm.ItemID}</td>
                            <td>{itm.ItemName}</td>
                            <td>{itm.Detail}</td>
                            <td>{itm.Quantity}</td>
                            <td>{itm.UserID}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GetItem.renderItemsTable(this.state.items);

        return (
            <div>
                <h1 id="tableLabel">Item Details</h1>
                <p>List of all items in the database</p>
                {contents}
            </div>
        );
    }


}
async function getItemList() {
    let response = await fetch('API/Item/ItemList');
    let data = await response.json();
    return data;
}
//const element = <ItemComponent></ItemComponent>
//ReactDOM.render(element, document.getElementById("root"));*/

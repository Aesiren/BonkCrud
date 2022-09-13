import React, { Component } from 'react';
import axios from 'axios';
import '../AddItem.css'
//import "./BonkCrud.data"
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';

export class AddItem extends Component {
    static displayName = AddItem.name;
    constructor(props) {
        super(props)
        this.state = {
            ItemName: '',
            Detail: '',
            Quantity: '',
            UserID: ''
            //TODO: add rest of Item table
        }
    }
    AddItem = () => {
        axios.post('https://localhost:44435/components/AddorUpdateItem/', { ItemName: this.state.ItemName, Detail: this.state.Detail, Quantity: this.state.Quantity })
            .then(json => {
                if (json.data.Status === 'Success') {
                    console.log(json.data.status);
                    alert("Data Save Successfully");
                    this.props.history.push('/ItemList')
                }
                else {
                    alert('Data not saved');
                    debugger;
                    this.props.history.push('/ItemList')
                }
            })
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    }

   render() {
     return (
           <Container itemName="App">
                <h4 className="PageHeading">Enter Item Information</h4>
                <Form itemName="form">
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>Item Name</Label>
                            <col sm={10}>
                                <Input type="text" name="ItemName" onChange={this.handleChange} value={this.state.ItemName} placeholder="Enter Name" />
                            </col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="detail" sm={2}>Description</Label>
                            <Col sm={10}>
                                <Input type="text" name="Detail" onChange={this.handlechange} value={this.state.Detail} placeholder="Enter Item Description" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="quantity" sm={2}>Quantity</Label>
                            <Col sm={10}>
                                <Input type="text" name="Quantity" onchange={this.handlechange} value={this.state.Quantity} placeholder="Enter quantity" />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}>
                            </Col>
                            <Col sm={1}>
                                <button type="button" onClick={this.AddItem} className="btn btn-success">Submit</button>
                            </Col>
                            <Col sm={1}>
                                <button color="danger">Cancel</button>{' '}
                            </Col>
                            <Col sm={5}>
                            </Col>
                        </FormGroup>
                    </Col>


                </Form>
            </Container>
         

        );
    }
}

//export default AddItem;
//export { AddItem };
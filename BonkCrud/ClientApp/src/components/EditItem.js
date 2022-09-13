import React, { Component } from 'react';
import { Container, Col, Form, /*Row,*/ FormGroup, Label, Input, Button } from 'reactstrap';
import axios from 'axios';
import '../AddItem.css'

export class EditItem extends Component { 
    static displayName = EditItem.name;
    constructor(props) {
        super(props)

        this.onChangeItemName = this.onChangeName.bind(this);
        this.onChangeDetail = this.onChangeDetail.bind(this);
        this.onChangeQuantity = this.onChangeQuantity.bind(this);
        //TODO: add owner
        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            ItemName: '',
            Detail: '',
            Quantity: ''
        }

    }

    componenetDidMount() {
        axios.get('https://https://localhost:44435/components/DeleteItem' + this.props.match.params.id)
            .then(response => {
                this.setState({
                    Name: response.data.Name,
                    Description: response.data.Description,
                    Quantity: response.data.Quantity
                });
            })
            .catch(function (error) {
                console.log(error);
            })
    }

    onChangeName(e) {
        this.setState({
            Name: e.target.value
        });
    }

    onChangeDetail(e) {
        this.setstate({
            Description: e.target.value
        })
    }

    onChangeQuantity(e) {
        this.setstate({
            Quantity: e.target.value
        })
    }

    onSubmit(e) {
        debugger;
        e.preventDefault();
        const obj = {
            Id:this.props.match.params.id,
            Name: this.state.Name,
            Description: this.state.Description,
            Quantity: this.state.Quantity
        };
        axios.post('https://localhost:44435/Api/Controllers/DeleteItem/', obj)
            .then(res => console.log(res.data));
        debugger;
        this.props.history.push('/GetItem')
    }

    render() {
        return (
            <Container className="App">
                
                <h4 classNAme="PageHeading">Update Item Information</h4>
                <Form className="form" onSubmit={this.onSubmit}>
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>Name</Label>
                            <Col sm={10}>
                                <Input type="text" name="Name" value={this.state.Name} onchange={this.onChangeName} placeholder="Enter Name" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Description" sm={2}>Description</Label>
                            <Col sm={10}>
                                <Input type="text" name="Description" value={this.state.Description} onchange={this.onChangeDetail} placeholder="Enter Description" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Quantity" sm={2}>Quantity</Label>
                            <Col sm={10}>
                                <Input type="number" name="Quantity" value={this.state.Quantity} onchange={this.onChangeQuantity} placeholder="Enter Quantity" />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}>
                            </Col>
                            <Col sm={1}>
                                <Button type="submit" color="success">Submit</Button>{' '}
                            </Col>
                            <Col sm={1}>
                                <Button color="danger">Cancel</Button>{' '}
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

//export default EditItem;
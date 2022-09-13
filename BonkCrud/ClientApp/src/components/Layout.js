import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import Navbar from 'react-bootstrap/Navbar';


function Layout(props) {
    return (
        <div>
            <NavMenu bg="primary" variant="dark" expand="lg">
                <Container>
                    <Navbar.brand>Users</Navbar.brand>
                    <Navbar.toggle aria-controls="basic-navbar-nav" />
                </Container>
            </NavMenu>
            <Container>{props.children}</Container>
        </div>
    );
}

/*export class Layout extends Component {
    static displayName = Layout.name;



    render() {
        return (
            <div>
                <NavMenu />
                <Container>
                    {this.props.children}
                </Container>
            </div>
        );
    }

}*/

export default Layout;

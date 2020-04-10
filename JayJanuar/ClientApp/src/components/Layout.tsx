import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import Home from './Home';

export default (props: { children?: React.ReactNode }) => (
    <React.Fragment>
        <NavMenu/>
        <Container>
            <Home/>
        </Container>
    </React.Fragment>
);

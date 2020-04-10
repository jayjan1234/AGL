import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import * as DisplayItemStore from '../store/DisplayItems';

// At runtime, Redux will merge together...
type DisplayItemProps =
    DisplayItemStore.DisplayItemState // ... state we've requested from the Redux store
    & typeof DisplayItemStore.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ startDateIndex: string }>; // ... plus incoming routing parameters
interface IMyComponentState {

}
class Home extends React.PureComponent<DisplayItemProps, IMyComponentState> {
    constructor(props: any) {
        super(props);
        this.state = {
        }
    }
    // This method is called when the component is first added to the document
    public componentDidMount() {
        this.getDisplayPersons();
    }
    public render() {
        return (
            <React.Fragment>
                <table className='table table-striped' aria-labelledby="tabelLabel" style={{ fontSize: 10 }}>
                    <thead>
                        <tr>
                            <th>Gender</th>
                            <th>Name</th>
                        </tr>
                    </thead>
                    {this.props.displayItems.map((displayItem) =>
                        <tbody>
                            <tr >
                                <td><b>{displayItem.gender}</b></td>
                                <td></td>
                            </tr>
                            {displayItem.names.map((name) =>

                                <tr >
                                    <td></td>
                                    <td>{name}</td>
                                </tr>
                            )}
                        </tbody>
                    )}
                </table>
            </React.Fragment>
        );
    }

    private getDisplayPersons() {
        this.props.requestDisplayItems("cat");
    }




}

export default connect(
    (state: ApplicationState) => state.displayItems, // Selects which state properties are merged into the component's props
    DisplayItemStore.actionCreators // Selects which action creators are merged into the component's props
)(Home as any);

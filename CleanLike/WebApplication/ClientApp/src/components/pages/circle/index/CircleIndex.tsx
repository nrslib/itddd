import * as React from "react";
import {RouteComponentProps} from "react-router";
import Circle from "../../../models/circles/CircleResponse";
import {Link} from "react-router-dom";

interface CircleIndexStatus {
    circles: Circle[]
}

export class CircleIndex extends React.Component<RouteComponentProps<{}>, CircleIndexStatus> {
    constructor(props: RouteComponentProps) {
        super(props);

        this.state = {
            circles: []
        };

        this.load();
    }

    public render() {
        return (
            <div>
                <h1>Circle Index</h1>
                {this.circleList()}
            </div>
        );
    }

    private circleList() {
        return (
            <table className="table">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Detail</th>
                    <th>Delete</th>
                </tr>
                </thead>
                <tbody>
                {this.state.circles.map(x =>
                    <tr key={x.id}>
                        <td>{x.id}</td>
                        <td><Link className="btn btn-default" to={`/circle/detail/${x.id}`}>Detail</Link></td>
                        <td><button className="btn btn-default" onClick={this.handleDeleteButtonClick.bind(this, x.id)}>Delete</button></td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    private load(): Promise<void> {
        return fetch('api/Circle')
            .then(res => res.json() as Promise<CircleIndexResponseModel>)
            .then(data => this.setState({circles: data.circles}));
    }

    private handleDeleteButtonClick(id: string) {
        fetch(`api/Circle/${id}`, { method: 'DELETE' })
            .then(_ => this.load());
    }
}

interface CircleIndexResponseModel {
    circles: Circle[]
}

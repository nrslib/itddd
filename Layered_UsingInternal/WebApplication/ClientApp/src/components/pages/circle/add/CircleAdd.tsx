import * as React from "react";
import {RouteComponentProps} from "react-router";
import {Link} from "react-router-dom";

interface CircleAddState {
    name: string
}

export class CircleAdd extends React.Component<RouteComponentProps<{}>, CircleAddState> {
    constructor(props: RouteComponentProps) {
        super(props);

        this.state = {
            name: ''
        };
    }

    public render(): JSX.Element | false | null {
        return (
            <div>
                <h1>Circle Add</h1>
                <form onSubmit={this.handleSubmit}>
                    <input type="text" value={this.state.name} onChange={this.handleNameChange}/>
                    <input type="submit" value="submit"/>
                </form>
                <Link to="/circle">Go back</Link>
            </div>
        );
    }

    private handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if(!this.state.name) {
            return;
        }

        const payload = {
            circleName: this.state.name
        };

        fetch('api/Circle', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(payload),
        })
            .then(res => res.json() as Promise<CircleAddResponseModel>)
            .then(data => {
                this.props.history.push(`/circle/detail/${data.createdCircleId}`)
            });
    };

    private handleNameChange = (e: React.FormEvent<HTMLInputElement>) => {
        this.setState({name: e.currentTarget.value});
    };
}

interface CircleAddResponseModel {
    createdCircleId: string;
}

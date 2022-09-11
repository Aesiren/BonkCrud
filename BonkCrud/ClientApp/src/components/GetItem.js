import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface GetItemDataState {
    itemList: ItemData[];
    loading: boolean;
}

export class GetItem extends React.Component<Route.Component<RouteComponentProps<{}>, GetItemDataState>{
    constructor() {
        super();
        this.state = { itemList: [], loading: true };

        fetch('api/Item/Index')
            .then(response => response.json() as Promise<ItemData[]>)
            .then(data => {
                this.setState({ itemList: data, loading: false });
            });

        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);
    }


}
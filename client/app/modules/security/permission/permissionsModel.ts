import {EventManager} from "../../../common/eventManager";

export class PermissionsModel {
    public actions: Array<any> = [];
    public eventKey = "permissions_onLoaded";
    public options: any = {
        data: [],
        columns: [
            { field: "name", title: "Name", index: 0 },
            { field: "key", title: "Key", index: 1 },
            { field: "description", title: "Description", index: 2 }
        ],

        enableEdit: true,
        enableDelete: true,
    }
    constructor() {

    }

    public import(items: Array<any>) {
        let eventManager: EventManager = window.ioc.resolve("IEventManager");
        eventManager.publish(this.eventKey, items);
    }

    public addAction(action: any) {
        this.actions.push(action);
    }
}
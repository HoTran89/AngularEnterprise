import {Component} from "angular2/core";
import {PageActions, Grid} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import {BasePage} from "../../../common/models/ui";
import {PermissionsModel} from "./permissionsModel";
import permissionService from "../_share/services/permissionService";

@Component({
    templateUrl: "app/modules/security/permission/permissions.html",
    directives: [PageActions, Grid]
})

export class Permissions extends BasePage {
    public model: PermissionsModel = new PermissionsModel();
    constructor() {
        super();
        let self: Permissions = this;
        self.model.addAction(new PageAction("btnAddPermission", "security.permissions.addPermissionAction",
            () => self.onAddPermissionClicked())
        )
        this.loadPermissions();
    }

    public onPermissionEditClicked(permission: any) {
        console.log(permission);
    }

    public onPermissionDeleteClicked(permission: any) {
        console.log(permission);
    }

    private loadPermissions() {
        let self = this;
        permissionService.getPermissions().then(function (response: Array<any>) {
            self.model.import(response);
        })
    }

    private onAddPermissionClicked() {
        console.log("onAddPermissionClicked");
    }
}
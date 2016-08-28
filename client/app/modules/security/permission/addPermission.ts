import {Component} from "angular2/core";
import {AddPermissionModel} from "./addPermissionModel";
import {Router, RouteParams} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import permissionService from "../_share/services/permissionService";
import {ValidationDirective} from "../../../common/directive";

@Component({
    templateUrl: "app/modules/security/permission/addPermission.html",
    directives: [ValidationDirective]
})

export class AddPermission extends BasePage {
    private router: Router;
    public model: AddPermissionModel = new AddPermissionModel();
    private permissionId: string;
    private isEdit: boolean = false;

    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self: AddPermission = this;
        self.router = router;
        self.permissionId = routeParams.get("id");
        if (self.permissionId) {
            self.isEdit = true;
            permissionService.getPermissionByid(self.permissionId).then(function (permission: any) {
                self.model = permission;
            })
        }
    }
    public onCancelClicked() {
        this.router.navigate(["Permissions"])
    };
    public onSaveClicked() {
        let self: AddPermission = this;
        console.log(self.model);

        // if (!self.model.validate()) {
        //     return;
        // }
        if (self.isEdit) {
            permissionService.updatePermission(self.model, self.permissionId).then(function () {
                self.router.navigate(["Permissions"]);
            })
        }
        else {
            permissionService.addPermission(self.model).then(function () {
                self.router.navigate(["Permissions"]);
            });
        };
    }
}
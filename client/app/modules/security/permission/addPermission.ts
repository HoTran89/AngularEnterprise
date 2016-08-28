import {Component} from "angular2/core";
import {AddPermissionModel} from "./addPermissionModel";
import {Router} from "angular2/router";
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
    constructor(router: Router) {
        super();
        this.router = router;
    }
    public onCancelClicked() {
        this.router.navigate(["Permissions"])
    };
    public onSaveClicked() {
        let self: AddPermission = this;
        if (!self.model.validate()) {
            return;
        }
        permissionService.addPermission(this.model).then(function () {
            self.router.navigate(["Permissions"]);
        });
    };
}
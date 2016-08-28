import {IModule, Module, MenuItem} from "../../../../common/models/layout";
import {Permissions} from "./../../permission/permissions";
import {Roles} from "./../../role/roles";
import {AuthenticationMode} from "../../../../common/enum";
import {AddPermission} from  "./../../permission/addPermission";

let umModule: IModule = createModule();
export default umModule;
function createModule() {
    let module = new Module("app/modules/security", "security");
    module.menus.push(
        new MenuItem(
            "Security", "/Permissions", "fa fa-edit",
            new MenuItem("Permissions", "/Permissions", "")
            // new MenuItem("Roles", "/Roles", "")
        )
    );
    module.addRoutes([
        { path: "/permissions", name: "Permissions", component: Permissions, data: { authentication: AuthenticationMode.Require } },
        { path: "/addPermission", name: "Add Permission", component: AddPermission, data: { authentication: AuthenticationMode.Require } },
         { path: "/editPermission", name: "Edit Permission", component: AddPermission, data: { authentication: AuthenticationMode.Require } },
        // { path: "/roles", name: "Roles", component: Roles }
    ]);
    return module;
}
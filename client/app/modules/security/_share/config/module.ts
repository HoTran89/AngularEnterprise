import {IModule, Module, MenuItem} from "../../../../common/models/layout";
import {Permissions} from "./../../permission/permissions";
import {Roles} from "./../../role/roles";

let umModule: IModule = createModule();
export default umModule;
function createModule() {
    let module = new Module("app/modules/security", "security");
    module.menus.push(
        new MenuItem(
            "Security", "/Permissions", "fa fa-edit",
            new MenuItem("Permissions", "/Permissions", ""),
            new MenuItem("Roles", "/Roles", "")
        )
    );
    module.addRoutes([
        { path: "/Permissions", name: "Permissions", component: Permissions },
        { path: "/Roles", name: "Roles", component: Roles }
    ]);
    return module;
}
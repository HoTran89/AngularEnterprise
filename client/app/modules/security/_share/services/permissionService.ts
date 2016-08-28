import {JsonHeaders} from "../../../../common/models/http";
import configHelper from "../../../../common/helpers/configHelper";

let permissionService = {
    getPermissions: getPermissions,
    deletePermission: deletePermission,
    addPermission: addPermission

};
export default permissionService;

function getPermissions() {
    let url = String.format("{0}permissions", configHelper.getAppConfig().api.baseUrl);
    let connector = window.ioc.resolve("IConnector");
    return connector.get(url);
}

function deletePermission(id: string) {
    let url = String.format("{0}/permissions/{1}", configHelper.getAppConfig().api.baseUrl, id);
    let connector = window.ioc.resolve("IConnector");
    return connector.delete(url);
}

function addPermission(permissions: any) {
    console.log(permissions);    
    let url = String.format("{0}permissions", configHelper.getAppConfig().api.baseUrl);
    let connector = window.ioc.resolve("IConnector");
    return connector.post(url, permissions);
}
import {JsonHeaders} from "../../../../common/models/http";
import configHelper from "../../../../common/helpers/configHelper";

let permissionService = {
    getPermissions: getPermissions,
    deletePermission: deletePermission,
    addPermission: addPermission,
    getPermissionByid: getPermissionByid,
    updatePermission: updatePermission
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

function addPermission(permission: any) {
    let url = String.format("{0}permissions", configHelper.getAppConfig().api.baseUrl);
    let connector = window.ioc.resolve("IConnector");
    return connector.post(url, permission);
}

function getPermissionByid(permissionsId: string) {
    let url = String.format("{0}permissions/{1}", configHelper.getAppConfig().api.baseUrl, permissionsId);
    let connector = window.ioc.resolve("IConnector");
    return connector.get(url);
}

function updatePermission(permission: any, permissionId: string) {
    let url = String.format("{0}permissions/{1}", configHelper.getAppConfig().api.baseUrl, permissionId);
    let connector = window.ioc.resolve("IConnector");
    return connector.put(url, permission);
}
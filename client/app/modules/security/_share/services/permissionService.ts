import {JsonHeaders} from "../../../../common/models/http";
import configHelper from "../../../../common/helpers/configHelper";

let permissionService = {
    getPermissions: getPermissions

};
export default permissionService;

function getPermissions() {
    let url = String.format("{0}/permissions", configHelper.getAppConfig().api.baseUrl);
    let connector = window.ioc.resolve("IConnector");
    let jsonHeaders = new JsonHeaders();
    return connector.get(url, jsonHeaders);
}
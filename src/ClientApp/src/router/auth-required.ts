import {getUserEmail, getUserToken, removeUser} from "@/utils/local-storage";

export default (to: any, from: any, next: any) => {
    let userEmail = getUserEmail();
    let userToken = getUserToken();
    
    if((userToken != null && userToken != '') && (userEmail !== null && userEmail != '')){
        next();
    }
    else{
        removeUser();
        next('/login');
    }
}

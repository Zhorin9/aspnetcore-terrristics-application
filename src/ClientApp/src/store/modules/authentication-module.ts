import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import {AlertModule} from "@/store/modules/alert-module";
import {userServiceImpl} from "@/services/user-service";
import {getUserEmail, getUserToken, isLoggedCorrect, setUser} from "@/utils/local-storage";
import router from "@/router";
import store from "@/store";

export interface AuthenticationState {
    Email: string;
    LogProcess: boolean;
    Roles: string[];
    Token: string;
}

@Module({dynamic: true, store, name: 'authenticationModule'})
class Authentication extends VuexModule implements AuthenticationState {
    public Email = getUserEmail();
    public LogProcess = false;
    public LoggedCorrect = isLoggedCorrect();
    public Roles: string[] = [];
    public Token = getUserToken();

    get AUTHENTICATION_GET_EMAIL() {
        return this.Email;
    }
    
    get AUTHENTICATION_IS_LOGGED_CORRECT(){
        return this.LoggedCorrect;
    }
    
    @Mutation
    private AUTHENTICATION_SET_TOKEN(token: string) {
        this.Token = token
    }

    @Mutation
    private AUTHENTICATION_SET_ROLES(roles: string[]) {
        this.Roles = roles
    }

    @Mutation
    private AUTHENTICATION_SET_EMAIL(email: string) {
        this.Email = email
    }

    @Mutation
    private AUTHENTICATION_UPDATE_LOG_PROCESS(email: string) {
        this.LogProcess = true;
        this.Email = email;
    } 
    
    @Mutation
    private AUTHENTICATION_LOGGED_CORRECT() {
        this.LogProcess = false;
        this.LoggedCorrect = true;
    }

    @Mutation
    private AUTHENTICATION_LOGGED_INCORRECT() {
        this.LogProcess = false;
        this.LoggedCorrect = false;
    }

    @Action
    public async LOGIN(user: UserLoginModel) {
        this.AUTHENTICATION_UPDATE_LOG_PROCESS(user.Email);

        return await userServiceImpl.login(user.Email, user.Password)
            .then(
                user => {
                    let userToken = user ? user.Token : "";
                    setUser(user);
                    this.AUTHENTICATION_SET_TOKEN(userToken);
                    this.AUTHENTICATION_LOGGED_CORRECT();

                    router.push({
                        name: 'HomeView'
                    });
                },
            ).catch(err => {
                AlertModule.ALERT_FAILED_LOGIN();
                this.AUTHENTICATION_LOGGED_INCORRECT();
                console.error("Problem with authentication", err);
            })
    }

    @Action
    public LOGOUT() {
        userServiceImpl.logout();

        // Reset visited views and cached views
        this.AUTHENTICATION_SET_TOKEN('');
        this.AUTHENTICATION_SET_ROLES([]);
        this.AUTHENTICATION_SET_EMAIL('');
    }
}

export const AuthenticationModule = getModule(Authentication);
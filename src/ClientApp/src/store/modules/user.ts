import {VuexModule, Module, Action, Mutation, getModule} from 'vuex-module-decorators'
import store from '@/store'
import {userServiceImpl} from "@/services/user-service";
import {getUserToken, removeUser, setUser} from "@/utils/local-storage";
import router from "@/router/router";

export interface IUserState {
    token: string
    name: string
    avatar: string
    introduction: string
    roles: string[]
}

@Module({dynamic: true, store, name: 'user'})
class User extends VuexModule implements IUserState {
    public token = getUserToken() || ''
    public name = ''
    public avatar = ''
    public introduction = ''
    public roles: string[] = []

    @Mutation
    private SET_TOKEN(token: string) {
        this.token = token
    }

    @Mutation
    private SET_NAME(name: string) {
        this.name = name
    }

    @Mutation
    private SET_AVATAR(avatar: string) {
        this.avatar = avatar
    }

    @Mutation
    private SET_INTRODUCTION(introduction: string) {
        this.introduction = introduction
    }

    @Mutation
    private SET_ROLES(roles: string[]) {
        this.roles = roles
    }

    @Action
    public async Login(user: { email: string, password: string }) {
        return await userServiceImpl.login(user.email, user.password)
            .then(
                user => {
                    let userToken = user ? user.Token : "";
                    setUser(user);
                    this.SET_TOKEN(userToken);

                    router.push({
                        name: 'HomeView'
                    });
                },
            ).catch(err => {
                this.LogOut();
                console.error("Problem with authentication", err);
            })
    }

    @Action
    public ResetToken() {
        removeUser();
        this.SET_TOKEN('');
        this.SET_ROLES([]);
    }

    @Action
    public async GetUserInfo() {
        if (this.token === '') {
            throw Error('GetUserInfo: token is undefined!')
        }
        // const {data} = await getUserInfo({ /* Your params here */})
        // if (!data) {
        //     throw Error('Verification failed, please Login again.')
        // }
        // const {roles, name, avatar, introduction} = data.user
        // // roles must be a non-empty array
        // if (!roles || roles.length <= 0) {
        //     throw Error('GetUserInfo: roles must be a non-null array!')
        // }
        // this.SET_ROLES(roles)
        // this.SET_NAME(name)
        // this.SET_AVATAR(avatar)
        // this.SET_INTRODUCTION(introduction)
    }

    @Action
    public async LogOut() {
        if (this.token === '') {
            throw Error('LogOut: token is undefined!')
        }
        removeUser()
        this.SET_TOKEN('')
        this.SET_ROLES([])
    }
}

export const UserModule = getModule(User);

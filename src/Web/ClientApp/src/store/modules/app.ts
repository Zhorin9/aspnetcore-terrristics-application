import {VuexModule, Module, Mutation, Action, getModule} from 'vuex-module-decorators'
import {getSidebarStatus, setSidebarStatus} from '@/utils/local-storage'
import store from '@/store'

export interface AppState {
    sidebar: {
        opened: boolean
        withoutAnimation: boolean
    }
}

@Module({dynamic: true, store, name: 'app'})
class App extends VuexModule implements AppState {
    public sidebar = {
        opened: getSidebarStatus() !== 'closed',
        withoutAnimation: false
    };
    public size = 'medium';

    @Mutation
    private TOGGLE_SIDEBAR(withoutAnimation: boolean) {
        this.sidebar.opened = !this.sidebar.opened;
        this.sidebar.withoutAnimation = withoutAnimation;
        if (this.sidebar.opened) {
            setSidebarStatus('opened')
        } else {
            setSidebarStatus('closed')
        }
    }

    @Mutation
    private CLOSE_SIDEBAR(withoutAnimation: boolean) {
        this.sidebar.opened = false;
        this.sidebar.withoutAnimation = withoutAnimation;
        setSidebarStatus('closed')
    }

    @Action
    public ToggleSideBar(withoutAnimation: boolean) {
        this.TOGGLE_SIDEBAR(withoutAnimation)
    }

    @Action
    public CloseSideBar(withoutAnimation: boolean) {
        this.CLOSE_SIDEBAR(withoutAnimation)
    }
}

export const AppModule = getModule(App);

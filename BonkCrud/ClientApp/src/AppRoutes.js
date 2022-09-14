import { AddItem } from "./components/AddItem";
import { EditItem } from "./components/EditItem";
import { GetItem } from "./components/GetItem";
//import { ItemCMD } from "./Controllers/ItemsController"
//import { AddUser } from "./components/AddUser";
//import { GetUser } from "./components/GetUser";
//import { EditUser } from "./components/EditUser";
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
    },
   /* {
        path: '/ItemCMD/',
        element: <ItemsController />
    },*/
  {
    path: '/counter',
    element: <Counter />
  },


    {
    path: '/fetch-data',
    element: <FetchData />
    },

  {
        path: '/GetItem',
        element: <GetItem />
    },
 /*   {
        path: '/GetUser',
        element: <GetUser />
    },*/

    {
        path: '/EditItem',
        element: <EditItem />
    },

  /*  {
        path: '/EditUser',
        element: <EditUser />
    },*/

    {
        path: '/AddItem',
        element: <AddItem />
    }//,

  /*  {
        path: '/AddUser',
        element: <AddUser />
    }*/


];

export default AppRoutes;

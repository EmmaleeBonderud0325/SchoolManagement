import { RouteInfo } from './sidebar.metadata';
export const ROUTES: RouteInfo[] = [
  {
    path: '',
    title: 'MENUITEMS.MAIN.TEXT',
    moduleName: '',
    iconType: '',
    icon: '',
    class: '',
    groupTitle: true,
    badge: '',
    badgeClass: '',
    submenu: [],
  },
  {
    path: '',
    title: 'MENUITEMS.HOME.TEXT',
    moduleName: 'teacher-home',
    iconType: 'feather',
    icon: 'monitor',
    class: 'menu-toggle',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [
      {
        path: '/teacher-home/lessons',
        title: 'MENUITEMS.HOME.LIST.TEACHER_LESSONS',
        moduleName: 'teacher-home',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
      }
    ],
  },
  {
    path: '',
    title: 'MENUITEMS.ADMIN.TEXT',
    moduleName: 'admin',
    iconType: 'feather',
    icon: 'monitor',
    class: 'menu-toggle',
    groupTitle: false,
    badge: '',
    badgeClass: '',
    submenu: [
      {
        path: '/admin/academic-level',
        title: 'MENUITEMS.ADMIN.LIST.ACADEMIC_LEVEL',
        moduleName: 'academic-level',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
      },
      {
        path: '/admin/academic-year',
        title: 'MENUITEMS.ADMIN.LIST.ACADEMIC_YEAR',
        moduleName: 'academic-year',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
      }
    ],
  }
  //section end
];

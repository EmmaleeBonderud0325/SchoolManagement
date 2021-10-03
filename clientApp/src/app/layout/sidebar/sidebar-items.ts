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
    isVisible: true
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
    isVisible: true,
    submenu: [
      {
        path: '/student-home',
        title: 'MENUITEMS.HOME.LIST.STUDENT-HOME',
        moduleName: 'student-home',
        iconType: 'feather',
        icon: 'monitor',
        class: 'menu-toggle',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        isVisible: true,
        submenu: [],
      },
      //lesson
      {
        path: '/teacher-home/lessons',
        title: 'MENUITEMS.HOME.LIST.TEACHER_LESSONS',
        moduleName: 'lessons',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible:true,
      },
      {
        path: '/teacher-home/essay-student-answer',
        title: 'MENUITEMS.HOME.LIST.ESSAY_STUDENT_LIST',
        moduleName: 'essay-student-answer',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible:true,
      },
      {
        path: '/teacher-home/essay-answer',
        title: 'MENUITEMS.HOME.LIST.ESSAY_QUESTION_ANSWER_LIST',
        moduleName: 'essay-answer',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },

      //question
      {
        path: '/teacher-home/question',
        title: 'MENUITEMS.HOME.LIST.TEACHER_QUESTION',
        moduleName: 'question',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },

      // mcq-question-answer
      {
        path: '/teacher-home/mcq-question-answer',
        title: 'MENUITEMS.HOME.LIST.TEACHER_MCQ_QUESTION_ANSWER',
        moduleName: 'mcq-question-answer',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible:true
      },


      // mcq-question-student-answer
      {
        path: '/teacher-home/mcq-question-student-answer',
        title: 'MENUITEMS.HOME.LIST.TEACHER_MCQ_QUESTION_STUDENT_ANSWER',
        moduleName: 'mcq-question-student-answer',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible:true
      },

      // student-mcq-question-answer
      {
        path: '/teacher-home/student-mcq-question',
        title: 'MENUITEMS.HOME.LIST.TEACHER_STUDENT_MCQ_QUESTION_ANSWER',
        moduleName: 'student-mcq-question',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible:true
      },
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
    isVisible: true,
    submenu: [
      {
        path: '/admin/user',
        title: 'MENUITEMS.ADMIN.LIST.USER',
        moduleName: 'user',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
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
        isVisible: true,
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
        isVisible: true
      },
      {
        path: '/admin/class-name',
        title: 'MENUITEMS.ADMIN.LIST.CLASS-NAME',
        moduleName: 'class-name',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
      {
        path: '/admin/class',
        title: 'MENUITEMS.ADMIN.LIST.CLASS',
        moduleName: 'class',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
      {
        path: '/admin/class-teacher',
        title: 'MENUITEMS.ADMIN.LIST.CLASS-TEACHER',
        moduleName: 'class-teacher',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
      {
        path: '/admin/student',
        title: 'MENUITEMS.ADMIN.LIST.STUDENT',
        moduleName: 'student',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
      {
        path: '/admin/subject',
        title: 'MENUITEMS.ADMIN.LIST.SUBJECT',
        moduleName: 'subject',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
      {
        path: '/admin/subject-teacher',
        title: 'MENUITEMS.ADMIN.LIST.SUBJECT_TEACHERS',
        moduleName: 'subject-teacher',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
       //Head Of Department
       {
        path: '/admin/head-of-department',
        title: 'MENUITEMS.ADMIN.LIST.HEAD_Of_DEPARTMENT',
        moduleName: 'head-of-department',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
      {
        path: '/admin/excel-upload',
        title: 'MENUITEMS.ADMIN.LIST.EXCEL_UPLOAD',
        moduleName: 'excel-upload',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      },
      {
        path: '/admin/report-genarate',
        title: 'MENUITEMS.ADMIN.LIST.REPORT_GENARATE',
        moduleName: 'report-genarate',
        iconType: '',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        badge: '',
        badgeClass: '',
        submenu: [],
        isVisible: true
      }

      
    ],
  }
 
];

<template>
    <div id="vendor">
        <!-- BEGIN PAGE HEAD-->
        <div class="page-head">
            <!-- BEGIN PAGE TITLE -->
            <div class="page-title">
                <h1>
                    {{ title }}
                    <small></small>
                </h1>
            </div>
            <!-- END PAGE TITLE -->
        </div>
        <!-- END PAGE HEAD-->
        <!-- BEGIN PAGE BREADCRUMB -->
        <ul class="page-breadcrumb breadcrumb">
            <li>
                <router-link :to="{ name: 'home' }">主页</router-link>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <a href="#">用户管理</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span class="active">{{ title }}</span>
            </li>
        </ul>
    

        <div class="row">
            <div class="col-md-12">
                <UserTable></UserTable>
            </div>
        </div>
    </div>
</template>

<script>
import UserTable from './UserTable.vue'

export default {
    name: 'user',
    components: {
        UserTable
    },
    data () {
        return {
            title: '用户列表'
        }
    }
}
</script>

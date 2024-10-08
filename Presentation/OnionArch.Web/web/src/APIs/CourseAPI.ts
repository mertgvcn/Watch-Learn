import { BaseAPI } from "./BaseAPI";
//models
import { AxiosResponse } from "axios";
import { EnrollCurrentUserInCourse } from "../models/paramaterModels/Course/EnrollCurrentUserInCourse";

class CourseAPI extends BaseAPI {
    private controllerExtension: string = "/Course"

    constructor() {
        super()
    }

    public async GetAllCourses(): Promise<AxiosResponse> {
        return await this.get(this.controllerExtension + '/GetAllCourses')
    }

    public async GetCourseDetailById(id: number): Promise<AxiosResponse> {
        return await this.get(this.controllerExtension + '/GetCourseDetailById', { id })
    }
    
    public async GetCurrentStudentCourses(): Promise<AxiosResponse> {
        return await this.get(this.controllerExtension + '/GetCurrentStudentCourses')
    }

    public async EnrollCurrentUserInCourse(params: EnrollCurrentUserInCourse): Promise<AxiosResponse> {
        return await this.post(this.controllerExtension + '/EnrollCurrentUserInCourse', params)
    }
}

export default new CourseAPI()
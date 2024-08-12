import { BaseAPI } from "./BaseAPI";
//models
import { AxiosResponse } from "axios";

class CourseAPI extends BaseAPI {
    private controllerExtension: string = "/Course"

    constructor() {
        super();
    }

    public async GetAllCourses(): Promise<AxiosResponse> {
        return await this.get(this.controllerExtension + '/GetAllCourses')
    }

    public async GetCourseById(id: number): Promise<AxiosResponse> {
        return await this.get(this.controllerExtension + '/GetCourseById', { id })
    }
}

export default new CourseAPI()
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";

@Injectable()
export class ImageHelper {
    readonly defaultFriendImageUrl: string = 'assets/default-profile-icon.jpg';
    readonly defaultGameImageUrl: string = 'assets/img-icon.svg';

    constructor(private httpClient: HttpClient) { }

    public async dataURLtoFile(dataurl, filename) {
        const response = await fetch(dataurl);
        const blob = await response.blob();
        var file = new File([blob], filename, { type: blob.type });
        return file;
    }

}

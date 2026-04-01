# BMI計算機
<img width="746" height="448" alt="image" src="https://github.com/user-attachments/assets/87efb2dd-7a21-407a-ab69-1995c54dd458" />



---

## 功能介紹

### 1. BMI 計算
使用者可以輸入：
- 身高（cm）
- 體重（kg）
- 性別（男 / 女）

按下「計算」後，系統會：
- 計算 BMI 值
- 顯示 BMI 數值
- 顯示體位結果
- 依照不同結果顯示不同顏色

### 2. 會員系統
系統提供簡單的會員功能：
- 註冊新帳號
- 登入既有帳號
- 顯示目前登入狀態

### 3. BMI 歷史紀錄
當使用者登入後，每次計算 BMI 時，系統會自動保存紀錄。  
之後可以透過歷史紀錄功能查看自己的 BMI 變化。

---

## BMI 判定標準

本系統使用以下 BMI 分類：

- BMI < 18.5：體重過輕
- 18.5 ≤ BMI < 24：健康體位
- 24 ≤ BMI < 27：體位過重
- 27 ≤ BMI < 30：輕度肥胖
- 30 ≤ BMI < 35：中度肥胖
- BMI ≥ 35：重度肥胖

---
## 操作說明

1. 開啟程式後，在左側輸入身高（cm）與體重（kg），並選擇性別。  
2. 若尚未擁有帳號，可先在右側會員系統輸入帳號與密碼，點擊「註冊」建立新會員。

 <p align="center">若無註冊帳號，則會顯示如圖。</p>                                              

<img width="744" height="465" alt="image" src="https://github.com/user-attachments/assets/af032d1e-bc40-4307-a176-44454a19e9d1" />

 <p align="center">註冊完成，則會顯示如圖。</p>                                              

<img width="747" height="453" alt="image" src="https://github.com/user-attachments/assets/59472914-941b-4793-86b6-8ea53c2f7603" />

3. 註冊完成後，輸入帳號與密碼並點擊「登入」，登入成功後會顯示目前登入狀態。

<img width="737" height="437" alt="image" src="https://github.com/user-attachments/assets/5175c21b-76d4-4296-a0f5-6ea555d22dfc" />

4. 登入後，按下「計算」即可計算 BMI，系統會顯示 BMI 數值與體位判定結果。
   
<img width="739" height="405" alt="image" src="https://github.com/user-attachments/assets/8c664f5d-e3fc-4d27-abb7-a210578fd652" />
  
5. 若目前為登入狀態，系統會自動將本次 BMI 結果保存到個人歷史紀錄中。  
6. 點擊「歷史紀錄」按鈕，可開啟新的視窗查看個人的 BMI 歷史變化圖。
   
<img width="989" height="588" alt="image" src="https://github.com/user-attachments/assets/298e717e-3786-4bec-8ade-8ef421e38b5d" />

7. 若未登入，仍可使用 BMI 計算功能，但系統不會保存本次紀錄。
   
<img width="743" height="433" alt="image" src="https://github.com/user-attachments/assets/7498e21d-6718-4f4d-8989-e63a70deb545" />

---

## 使用技術

- C#
- Windows Forms
- .NET Framework / .NET Windows Forms
- 檔案讀寫（`System.IO`）

---

## 專案檔案說明

### `frmBMI.cs`
主畫面程式碼，負責：
- BMI 計算
- 輸入驗證
- 顯示計算結果
- 會員登入與註冊
- 保存 BMI 紀錄
- 開啟歷史紀錄視窗

### `frmHistory.cs`
歷史紀錄視窗，負責：
- 載入目前登入使用者的 BMI 紀錄
- 顯示歷史資料
- 使用圖表呈現 BMI 變化

### `users.txt`
儲存會員帳號與密碼。  
格式如下：

```text
帳號,密碼
<img width="970" height="613" alt="image" src="https://github.com/user-attachments/assets/b9a77f8a-e286-4ec7-aafd-da0c123df4a0" />
